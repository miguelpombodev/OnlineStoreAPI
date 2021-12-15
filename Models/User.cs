using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Base;

namespace OnlineStore.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(15, ErrorMessage = "This field must contain between 3 or 15 characters")]
        [MinLength(3, ErrorMessage = "This field must contain between 3 or 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(150, ErrorMessage = "This field must contain between 3 or 150 characters")]
        [MinLength(3, ErrorMessage = "This field must contain between 3 or 150 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "This field must be 11 characters")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not in a valid format")]

        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "This field must be 11 characters")]
        public string Cellphone { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "This field be between 2 and 100 characters")]
        public string Address { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "This field be between 2 and 50 characters")]
        public string Neighborhood { get; set; }

        [StringLength(30, MinimumLength = 2, ErrorMessage = "This field be between 2 and 30 characters")]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "This field must be 2 characters")]
        public string UF { get; set; }
    }
}