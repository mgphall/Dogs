using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("breed")]
    public class Breeds
    {
        [Key]
        [Column("BreedId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Breed is required")]
        [StringLength(60, ErrorMessage = "Breed can't be longer than 60 characters")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "GroupdId is required")]
        public Guid GroupdId { get; set; }
    }
}
