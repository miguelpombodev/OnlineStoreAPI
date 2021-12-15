using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DataContext _context;

        private DbSet<T> dataset;

        public GenericRepository(DataContext context)
        {
            _context = context;
            dataset = _context.Set<T>();

        }

        public async Task<dynamic> Create(T item)
        {
            var itemExists = dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (itemExists != null)
            {
                return new { message = "O produto já existe" };
            }

            try
            {
                dataset.Add(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            //var product = await _context.Product.FirstOrDefaultAsync(product => product.Id == id);

            //if (product != null)
            //{
            //    try
            //    {
            //        _context.Product.Remove(product);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (System.Exception)
            //    {
            //        throw;
            //    }
            //}
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            var items = await dataset.ToListAsync();

            return items;
        }

        public async Task<T> GetByID(Guid id)
        {
            var item = await dataset.FirstOrDefaultAsync(product => product.Id == id);

            if (item == null)
            {
                return null;
            }

            return item;
        }

        public async Task<T> Update(Guid id, T item)
        {
            item.Id = id;

            var itemExists = await _context.Product.SingleOrDefaultAsync(x => x.Id == item.Id);

            if (itemExists == null)
            {
                return null;
            }

            try
            {
                _context.Entry(itemExists).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                var updatedItem = await GetByID(item.Id);

                return updatedItem;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //   return BadRequest(new { message = "Este registro já foi atualizado" });
            // }
            // catch (Exception)
            // {
            //   return BadRequest(new { message = "Não foi possível atualizar a categoria" });
            // }
        }
    }
}
