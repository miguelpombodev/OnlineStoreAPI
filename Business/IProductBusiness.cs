using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Business.Implementations
{
  public interface IProductBusiness
  {
    Task<dynamic> Create(Product product);
    Task<Product> GetByID(Guid id);
    Task<List<Product>> GetAll();
    Task<Product> Update(Guid id, Product product);
    void Delete(Guid id);
  }
}