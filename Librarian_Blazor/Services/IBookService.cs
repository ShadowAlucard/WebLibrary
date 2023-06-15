using Library_DB;

namespace Librarian_Blazor.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetAllBooksAsync();
        
        Task<Book?> GetBookByIdAsync(int id);

        Task UpdateBookAsync(int id, Book book);

        Task DeleteBookAsync(int id);

        Task AddBookAsync(Book book);
    }
}