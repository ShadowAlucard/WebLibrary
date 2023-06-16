namespace Library_DB.Models
{
    public class LoanWithNames
    {
        public string ReaderNumber { get; set; }  //olvasószám
        public string Name { get; set; }
        public int BookId { get; set; }
        public string InventoryNumber { get; set; } //leltári szám
        public string Title { get; set; }
        public DateTime LoanDate { get; set; }

        public DateTime ReturnDeadline { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
