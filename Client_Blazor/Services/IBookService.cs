﻿namespace Client_Blazor.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetAllBookAsync();

        Task<Book?> GetBookByIdAsync(int id);
    }

    public interface ILoanService
    {
        Task<IEnumerable<Loan>?> GetAllLoanAsync();

        Task<Loan?> GetLoanByIdAsync(int id);
    }
}
