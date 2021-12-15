using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}