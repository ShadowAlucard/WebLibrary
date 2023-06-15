using System.Net.Http.Json;
using Library_Contract;

namespace Librarian_Blazor.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBookAsync(Book book) =>
            await _httpClient.PostAsJsonAsync("Books", book);

        public async Task DeleteBookAsync(int id) =>
            await _httpClient.DeleteAsync($"Books/{id}");

        public async Task<IEnumerable<Book>?> GetAllBooksAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Book>?>("Books");

        public async Task<Book?> GetBookByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Book?>($"Books/{id}");

        public async Task UpdateBookAsync(int id, Book book) =>
            await _httpClient.PutAsJsonAsync($"Books/{id}", book);
    }
}
