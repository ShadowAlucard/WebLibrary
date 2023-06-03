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
            var existingLoan = await _libraryContext.Loans.FindAsync();

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Loan loan)
        {
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

            existingLoan.MemberId = loan.Id;
            existingLoan.BookId = loan.BookId;
            existingLoan.LoanDate = loan.LoanDate;
            existingLoan.ReturnDeadline = loan.ReturnDeadline;

            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
