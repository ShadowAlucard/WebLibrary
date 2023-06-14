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

        public Task<IEnumerable<Book>?> GetAllBookAsync() => 
            _httpClient.GetFromJsonAsync<IEnumerable<Book>>("Lib_Books");

        public Task<Book?> GetBookByIdAsync(int id) =>
            _httpClient.GetFromJsonAsync<Book?>($"Lib_Books/{id}");
    }

    public class LoanService : ILoanService
    {
        private readonly HttpClient _httpClient;

        public LoanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Loank>?> GetAllLoanAsync() =>
            _httpClient.GetFromJsonAsync<IEnumerable<Loan>>("MyLoan");

        public Task<Loan?> GetLoanByIdAsync(int id) =>
            _httpClient.GetFromJsonAsync<Loan?>($"MyLoan/{id}");
    }
}
