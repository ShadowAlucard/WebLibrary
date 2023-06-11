using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_DB
{
    public class Loan
    {
       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            public int ReaderNumber { get; set; }  //olvasószám

            [Required]
            public int InventoryNumber { get; set; } //leltári szám

            [Required]
            public DateTime LoanDate { get; set; }

            [Required]

            public DateTime ReturnDeadline { get; set; }
        
    }
}
