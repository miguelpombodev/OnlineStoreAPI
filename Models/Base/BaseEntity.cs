using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models.Base
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}