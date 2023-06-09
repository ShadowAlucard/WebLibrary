﻿using Library_Contract;

namespace Client_Blazor.Services
{
    public interface ILibraryMemberService
    {
        Task<IEnumerable<LibraryMember>?> GetAllLibraryMembersAsync();

        Task<LibraryMember?> GetLibraryMemberByIdAsync(int id);

        Task UpdateLibraryMemberAsync(int id, LibraryMember libraryMember);

        Task DeleteLibraryMemberAsync(int id);

        Task AddLibraryMemberAsync(LibraryMember libraryMember);
    }
}
