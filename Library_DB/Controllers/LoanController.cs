using Library_DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Library_DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly LibraryContext _libraryContext;
        private readonly ILogger<LoanController> _logger;


        public LoanController(LibraryContext libraryContext, ILogger<LoanController> logger)
        {
            _libraryContext = libraryContext;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingLoan = await _libraryContext.Loans.FindAsync(id);

            if (existingLoan is null)
            {
                return NotFound();
            }

            _libraryContext.Loans.Remove(existingLoan);
            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> Get()
        {
            var loans = await _libraryContext.Loans.ToListAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> Get(int id)
        {
            var loan = await _libraryContext.Loans.FindAsync(id);

            if (loan is null)
            {
                return NotFound();
            }

            return Ok(loan);
        }
        //Tag által kölcsönzött könyvek adatainak megjelenítése
        [HttpGet("loanedbooks/{membernumber}")]
        public async Task<ActionResult<Loan>> GetMemberLoanedBooks(string membernumber)
        {
            //Táblák összekapcsolása LINQ segítségével, megfelelő adatok visszaadása.

            var loan = (from l in _libraryContext.Loans
                        join lm in _libraryContext.LibraryMembers on l.ReaderNumber equals lm.ReaderNumber
                        join lb in _libraryContext.Books on l.InventoryNumber equals lb.InventoryNumber
                        where l.ReaderNumber == membernumber
                        orderby l.ReturnDeadline
                        select new MemberLoanedBooks()
                        {
                            Id = l.Id,
                            BookName = lb.Title,
                            LoanDate = l.LoanDate,
                            ReturnDate = l.ReturnDate,
                            ReturnDeadline = l.ReturnDeadline

                        }).ToList();

            if (loan is null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Loan loan)
        {
            try
            {
                var IsBookBorrowed = await _libraryContext.Loans
                    .Where(x => x.InventoryNumber == loan.InventoryNumber && loan.ReturnDate == null).AnyAsync();

                if (IsBookBorrowed)
                {
                    return BadRequest("Book is already borrowed");
                }
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }

            var IsBookExist = await _libraryContext.Books
                .Where(x => x.InventoryNumber == loan.InventoryNumber).AnyAsync();
            if (!IsBookExist)
            {
                return BadRequest("Book with given inventorynumber doesn't exists.");
            }
            var IsMemberExist = await _libraryContext.LibraryMembers
                .Where(x => x.ReaderNumber == loan.ReaderNumber).AnyAsync();
            if (!IsMemberExist)
            {
                return BadRequest("Member with given readernumber doesn't exists");
            }

            var LoanedBook = _libraryContext.Books
                .Where(x => x.InventoryNumber == loan.InventoryNumber).FirstOrDefault();

            LoanedBook.IsBorrowed = true;
            _libraryContext.Loans.Add(loan);
            await _libraryContext.SaveChangesAsync();

            return Ok();
        }
        //Kölcsönzés
        [HttpPost("/borrow")]
        public async Task<IActionResult> Borrow([FromBody] Loan loan)
        {
            try
            {
                var IsBookBorrowed = await _libraryContext.Loans
                    .Where(x => x.InventoryNumber == loan.InventoryNumber && loan.ReturnDate == null).AnyAsync();

                if (IsBookBorrowed)
                {
                    return BadRequest("Book is already borrowed.");
                }
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }
            var LoanedBook = _libraryContext.Books
               .Where(x => x.InventoryNumber == loan.InventoryNumber).FirstOrDefault();
            if (LoanedBook is null)
            {
                return BadRequest("Book with given inventorynumber doesn't exists.");
            }
            var IsMemberExist = await _libraryContext.LibraryMembers
                .Where(x => x.ReaderNumber == loan.ReaderNumber).AnyAsync();
            if (!IsMemberExist)
            {
                return BadRequest("Member with given readernumber doesn't exists");
            }

            LoanedBook.IsBorrowed = true;
            _libraryContext.Loans.Add(loan);
            await _libraryContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }

            var existingLoan = await _libraryContext.Loans.FindAsync(id);

            if (existingLoan is null)
            {
                return NotFound();
            }

            try
            {
                var IsBookBorrowed = await _libraryContext.Loans
                    .Where(x => x.InventoryNumber == loan.InventoryNumber && loan.ReturnDate == null).AnyAsync();

                if (IsBookBorrowed)
                {
                    return BadRequest("Book is already borrowed.");
                }
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }

            existingLoan.ReaderNumber = loan.ReaderNumber;
            existingLoan.InventoryNumber = loan.InventoryNumber;
            existingLoan.LoanDate = loan.LoanDate;
            existingLoan.ReturnDeadline = loan.ReturnDeadline;

            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }
        //visszahozás
        [HttpPut("return/{id}")]
        public async Task<IActionResult> Return(int id, DateTime returnDate)
        {
            var existingLoan = await _libraryContext.Loans.FindAsync(id);

            if (existingLoan is null)
            {
                return NotFound();
            }

            if (existingLoan.ReturnDate is not null)
            {
                return BadRequest("Book is already returned.");
            }

            var ReturnedBook = _libraryContext.Books
               .Where(x => x.InventoryNumber == existingLoan.InventoryNumber).FirstOrDefault();
            if (ReturnedBook is null)
            {
                return BadRequest("Book with given inventorynumber doesn't exists.");
            }
            ReturnedBook.IsBorrowed = false;
            existingLoan.ReturnDate = returnDate;

            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
