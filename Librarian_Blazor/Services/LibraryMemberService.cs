using Library_DB;
using System.Net.Http.Json;

namespace Librarian_Blazor.Services
{
    public class LibraryMemberService : ILibraryMemberService
    {
        private readonly HttpClient _httpClient;

        public LibraryMemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddLibraryMemberAsync(LibraryMember libraryMember) =>
            await _httpClient.PostAsJsonAsync("LibraryMember", libraryMember);

        public async Task DeleteLibraryMemberAsync(int id) =>
            await _httpClient.DeleteAsync($"LibraryMember/{id}");

        public async Task<IEnumerable<LibraryMember>?> GetAllLibraryMembersAsync() =>
            await _httpClient.GetFromJsonAsync<IEnumerable<LibraryMember>?>("LibraryMember");

        public async Task<LibraryMember?> GetLibraryMemberByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<LibraryMember?>($"LibraryMember/{id}");

        public async Task UpdateLibraryMemberAsync(int id, LibraryMember libraryMember) =>
            await _httpClient.PutAsJsonAsync($"LibraryMember/{id}", libraryMember);
    }
}
