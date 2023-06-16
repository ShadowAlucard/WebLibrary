using Library_Contract;

namespace Client_Blazor.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>?> GetAllLoansAsync();

        Task<Loan?> GetLoanByIdAsync(int id);

        Task<IEnumerable<Loan>?> GetAllLoansByMemberNumberAsync(string memberNumber);

        Task UpdateLoanAsync(int id, Loan loan);

        Task DeleteLoanAsync(int id);

        Task AddLoanAsync(Loan loan);

        Task ReturnAsync(int id);
    }
}
