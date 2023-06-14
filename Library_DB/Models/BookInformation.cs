namespace Library_DB.Models
{
    public class BookInformation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsBorrowed { get; set; }
        public string Name { get; set; }
        public DateTime? ReturnDeadline { get; set; }
    }
}
