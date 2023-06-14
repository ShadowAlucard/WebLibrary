using Microsoft.EntityFrameworkCore;

namespace Library_DB
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<LibraryMember> LibraryMembers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
    }
}
