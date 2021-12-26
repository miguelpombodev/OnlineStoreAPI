using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models.Base;
using System;
using System.Collections.Generic;
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
            item.Id = Guid.NewGuid();
            var itemExists = await dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (itemExists != null)
            {
                return null;
            }


            try
            {
                dataset.Add(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(product => product.Id == id);

            if (product != null)
            {
                try
                {
                    _context.Product.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

            return false;
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
            try
            {
                _context.Entry<T>(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var updatedItem = await GetByID(item.Id);

                return updatedItem;
            }
            catch (DbUpdateConcurrencyException db)
            {
                throw db;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
