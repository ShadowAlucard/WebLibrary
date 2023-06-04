using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_DB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryMemberController : ControllerBase
    {
        private readonly LibraryContext _libraryContext;
        private readonly ILogger<LibraryMemberController> _logger;

        public LibraryMemberController(LibraryContext libraryContext, ILogger<LibraryMemberController> logger)
        {
            _libraryContext = libraryContext;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existinglibraryMember = await _libraryContext.LibraryMembers.FindAsync(id);

            if (existinglibraryMember is null)
            {
                return NotFound();
            }

            _libraryContext.LibraryMembers.Remove(existinglibraryMember);
            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryMember>>> Get()
        {
            var librarymembers = await _libraryContext.LibraryMembers.ToListAsync();
            return Ok(librarymembers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryMember>> Get(int id)
        {
            var librarymember = await _libraryContext.LibraryMembers.FindAsync(id);

            if (librarymember is null)
            {
                return NotFound();
            }

            return Ok(librarymember);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LibraryMember libraryMember)
        {
            _libraryContext.LibraryMembers.Add(libraryMember);
            await _libraryContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LibraryMember libraryMember)
        {
            if (id != libraryMember.Id)
            {
                return BadRequest();
            }

            var existinglibraryMember = await _libraryContext.LibraryMembers.FindAsync(id);

            if (existinglibraryMember is null)
            {
                return NotFound();
            }

            existinglibraryMember.Name = libraryMember.Name;
            existinglibraryMember.Address = libraryMember.Address;
            existinglibraryMember.ReaderNumber = libraryMember.ReaderNumber;
            existinglibraryMember.BirthDate = libraryMember.BirthDate;

            await _libraryContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
