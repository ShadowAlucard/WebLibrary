using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_DB
{
    public class Loan : IValidatableObject
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ReaderNumber { get; set; }  //olvasószám

        [Required]
        public string InventoryNumber { get; set; } //leltári szám

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]

        public DateTime ReturnDeadline { get; set; }

        public DateTime? ReturnDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReturnDeadline.Date < LoanDate.Date)
            {
                yield return new ValidationResult("ReturnDeadline is before than Loandate");
            }
        }

    }
}
