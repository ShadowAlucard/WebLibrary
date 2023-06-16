using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client_Blazor.Temp
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [MaxLength(13)]
        public string InventoryNumber { get; set; }
        [Required]
        public int PublicationYear { get; set; }

        public bool IsBorrowed { get; set; }
    }
}
