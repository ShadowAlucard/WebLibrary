namespace Client_Blazor.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookClass>?> GetAllBookAsync();

        Task<BookClass?> GetBookByIdAsync(int id);
    }
}
