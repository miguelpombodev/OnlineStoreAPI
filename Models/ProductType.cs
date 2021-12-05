using OnlineStore.Models.Base;

namespace OnlineStore.Models
{
  public class ProductType : BaseEntity
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
  }
}