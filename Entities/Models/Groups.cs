namespace Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("group")]
    public class Groups
    {
        [Key]
        public Guid GroupdId { get; set; }

        [Required(ErrorMessage = "Group is required")]
        [StringLength(60, ErrorMessage = "Group can't be longer than 60 characters")]
        public string GroupName { get; set; }
    }
}
