using System;
using System.ComponentModel.DataAnnotations;
using OnlineStore.Data;
using OnlineStore.Shared.Interfaces;

namespace OnlineStore.Models.Base
{
  public class BaseEntity
  {
    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }
  }
}