using System;

namespace OnlineStore.Shared.Interfaces
{
  public interface ITiming
  {
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
  }
}