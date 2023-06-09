﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Contract
{
    public class LibraryMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [RegularExpression(@"^[A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+([- ][A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+)*$")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ReaderNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}