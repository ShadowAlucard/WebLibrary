using System.Net.Http.Json;
using Library_Contract;
using Library_DB;

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
            _httpClient.GetFromJsonAsync<IEnumerable<Book>>("Book");

        public Task<Book?> GetBookByIdAsync(int id) =>
            _httpClient.GetFromJsonAsync<Book?>($"Book/{id}");
    }

    public class LoanService : ILoanService
    {
        private readonly HttpClient _httpClient;

        public LoanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Loan>?> GetAllLoanAsync() =>
            _httpClient.GetFromJsonAsync<IEnumerable<Loan>>("Loan");

        public Task<Loan?> GetLoanByIdAsync(int id) =>
            _httpClient.GetFromJsonAsync<Loan?>($"Loan/{id}");
    }

    public class MemberService : IMemberService
    {
        private readonly HttpClient _httpClient;

        public MemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<LibraryMember>?> GetAllMemberAsync() =>
            _httpClient.GetFromJsonAsync<IEnumerable<LibraryMember>>("LibraryMember");

        public Task<LibraryMember?> GetMemberByIdAsync(int id) =>
            _httpClient.GetFromJsonAsync<LibraryMember?>($"LibraryMember/{id}");
    }
}
