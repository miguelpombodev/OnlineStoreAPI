using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStore.Models.Base;

namespace OnlineStore.Models
{
  public class Product : BaseEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid Product Type")]
    public int TypeId { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [MaxLength(15, ErrorMessage = "This field must contain between 3 or 15 characters")]
    [MinLength(3, ErrorMessage = "This field must contain between 3 or 15 characters")]
    public string Sku { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [MaxLength(20, ErrorMessage = "This field must contain between 3 or 15 characters")]
    [MinLength(3, ErrorMessage = "This field must contain between 3 or 15 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Price must be bigger than zero")]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public int StockAmount { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.ImageUrl)]
    public string ProductUrl { get; set; }

  }
}