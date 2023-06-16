using Library_Contract;

namespace Librarian_Blazor.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetAllBooksAsync();
        
        Task<Book?> GetBookByIdAsync(int id);

        Task<Book?> GetBookByInventoryNumberAsync(string inventoryNumber);

        Task UpdateBookAsync(int id, Book book);

        Task DeleteBookAsync(int id);

        Task AddBookAsync(Book book);
    }
}