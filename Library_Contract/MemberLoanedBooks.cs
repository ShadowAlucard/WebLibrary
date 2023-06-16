namespace Library_Contract
{
    public class MemberLoanedBooks
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string InventoryNumber { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDeadline { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
