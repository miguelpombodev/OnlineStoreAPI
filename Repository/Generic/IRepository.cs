using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Models;
using OnlineStore.Models.Base;

namespace OnlineStore.Repository.Generic
{
  public interface IRepository<T> where T : BaseEntity
    {
    Task<dynamic> Create(T item);
    Task<T> GetByID(Guid id);
    Task<List<T>> GetAll();
    Task<T> Update(Guid id, T item);
    Task<bool> Delete(Guid id);
  }
}