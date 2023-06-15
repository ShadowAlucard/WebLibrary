using Library_Contract;
using System.Net.Http.Json;

namespace Librarian_Blazor.Services
{
    public class LoanService : ILoanService
    {
        private readonly HttpClient _httpClient;

        public LoanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddLoanAsync(Loan loan) =>
            await _httpClient.PostAsJsonAsync("Loan", loan);

        public async Task DeleteLoanAsync(int id) =>
            await _httpClient.DeleteAsync($"Loan/{id}");

        public async Task<IEnumerable<Loan>?> GetAllLoansAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Loan>?>("Loan");

        public async Task<IEnumerable<Loan>?> GetAllLoansByMemberNumberAsync(string memberNumber) =>
            await _httpClient.GetFromJsonAsync<IEnumerable<Loan>?>($"Loan/loanedbooks/{memberNumber}");

		public async Task<Loan?> GetLoanByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Loan?>($"Loan/{id}");

        public async Task UpdateLoanAsync(int id, Loan loan) =>
            await _httpClient.PutAsJsonAsync($"Loan/{id}", loan);
    }
}
