using System.Net.Http.Json;

namespace Client_Blazor.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }

        public Task<IEnumerable<BookClass>?> GetAllBookAsync() => 
            _httpClient.GetFromJsonAsync<IEnumerable<BookClass>>("Lib_Books");

        public Task<BookClass?> GetBookByIdAsync(int id) =>
            _httpClient.GetFromJsonAsync<BookClass?>($"Lib_Books/{id}");
    }
}
