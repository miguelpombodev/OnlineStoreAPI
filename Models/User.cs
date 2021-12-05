using System.ComponentModel.DataAnnotations;
using OnlineStore.Models.Base;

namespace OnlineStore.Models
{
  public class User : BaseEntity
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [MaxLength(15, ErrorMessage = "This field must contain between 3 or 15 characters")]
    [MinLength(3, ErrorMessage = "This field must contain between 3 or 15 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [MaxLength(150, ErrorMessage = "This field must contain between 3 or 150 characters")]
    [MinLength(3, ErrorMessage = "This field must contain between 3 or 150 characters")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [MaxLength(11, ErrorMessage = "This field must contain between 3 or 150 characters")]
    [MinLength(11, ErrorMessage = "This field must contain between 3 or 150 characters")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not in a valid format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.PhoneNumber)]
    [MaxLength(11, ErrorMessage = "This field must contain between 3 or 11 characters")]
    [MinLength(11, ErrorMessage = "This field must contain between 3 or 11 characters")]
    public string Cellphone { get; set; }

    [Required(ErrorMessage = "This field is required")]
    public string Address { get; set; }
  }
}