using Library_DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_DB.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _libraryContext;
        private readonly ILogger<BooksController> _logger;

        public BooksController(LibraryContext libraryContext, ILogger<BooksController> logger)
        {
            _libraryContext = libraryContext;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBook = await _libraryContext.Books.FindAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            _libraryContext.Books.Remove(existingBook);
            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            _logger.LogInformation("Books endpoint was called");
            var books = await _libraryContext.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _libraryContext.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        //könyv állapotának lekérdezése
        [HttpGet("status/{id}")]
        public async Task<ActionResult<Book>> GetBookWithLoaner(int id)
        {
            var book = await _libraryContext.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            var loanofbook = (from l in _libraryContext.Loans
                              join lb in _libraryContext.Books on l.InventoryNumber equals lb.InventoryNumber
                              join lm in _libraryContext.LibraryMembers on l.ReaderNumber equals lm.ReaderNumber
                              where l.InventoryNumber == book.InventoryNumber
                              orderby l.LoanDate descending
                              select new BookInformation()
                              {
                                  Id = l.Id,
                                  Title = book.Title,
                                  IsBorrowed = book.IsBorrowed,
                                  Name = lm.Name,
                                  ReturnDeadline = l.ReturnDeadline
                              }).FirstOrDefault();

            if (loanofbook is null)
            {
                loanofbook = new BookInformation()
                {
                    Title = book.Title,
                    IsBorrowed = null,
                    ReturnDeadline = null,
                };
            }

            return Ok(loanofbook);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                var IsBookExist = await _libraryContext.Books
                    .Where(x => x.InventoryNumber == book.InventoryNumber).AnyAsync();

                if (IsBookExist)
                    return BadRequest("Book is already exists with this inventorynumber");
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }

            _libraryContext.Books.Add(book);
            await _libraryContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _libraryContext.Books.FindAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            try
            {
                var IsBookExist = await _libraryContext.Books
                    .Where(x => x.InventoryNumber == book.InventoryNumber).AnyAsync();

                if (IsBookExist)
                    return BadRequest("Book is already exists with this inventorynumber");
            }
            catch (ArgumentNullException ex)
            {
                throw;
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Publisher = book.Publisher;
            existingBook.InventoryNumber = book.InventoryNumber;
            existingBook.PublicationYear = book.PublicationYear;

            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

