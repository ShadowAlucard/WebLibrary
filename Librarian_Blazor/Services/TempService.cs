using Library_Contract;

namespace Librarian_Blazor.Services
{
    public class TempService
    {
        public readonly List<LibraryMember> members = new List<LibraryMember>
        {
            new LibraryMember
            {
                Id = 1,
                Name = "Kiss Pista",
                Address = "Kerek utca 10",
                BirthDate = new DateTime(2002,5,22),
                ReaderNumber = "10ef"
            },
            new LibraryMember
            {
                Id = 2,
                Name = "Kalap Pál",
                Address = "Kerek utca 11",
                BirthDate = new DateTime(1970,12,27),
                ReaderNumber = "1f21f"
            },
            new LibraryMember
            {
                Id = 3,
                Name = "Orbán Viktor",
                Address = "Parlament utca xd",
                BirthDate = DateTime.Now.AddDays(-1420),
                ReaderNumber = "fffff"
            },
            new LibraryMember
			{
				Id = 4,
                Name = "Kiss Géza Gáspár",
                Address = "0670 tininindzsabetmen",
                BirthDate = DateTime.Now.AddDays(-10000),
                ReaderNumber = "féreglyuk"
            }
        };

        public readonly List<Book> books = new List<Book>
        {
            new Book
            {
                Author = "James mc",
                Id = 1,
                InventoryNumber = "10",
                IsBorrowed = false,
                PublicationYear = 2002,
                Publisher = "James mc Corp.",
                Title = "Ti küldtétek"
            },
            new Book
            {
                Author = "János legyen xd",
                Id = 2,
                InventoryNumber = "11210",
                IsBorrowed = false,
                PublicationYear = 2002,
                Publisher = "James mc Corp.",
                Title = "Ti küldtétek"
            },
            new Book
            {
                Author = "Jane Doe",
                Id = 5,
                InventoryNumber = "XYZ456",
                IsBorrowed = false,
                PublicationYear = 2018,
                Publisher = "XYZ Publications",
                Title = "The Secret Code"
            },
            new Book
            {
                Author = "John Green",
                Id = 3,
                InventoryNumber = "DEF789",
                IsBorrowed = false,
                PublicationYear = 2015,
                Publisher = "ABC Publishing",
                Title = "The Fault in Our Stars"
            },
        };

        public readonly List<Loan> loans = new List<Loan>();
	}
}
