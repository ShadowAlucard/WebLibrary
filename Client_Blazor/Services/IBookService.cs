namespace Client_Blazor.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookClass>?> GetAllBook();
    }
}
