using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

using OnlineStore.Models;

namespace OnlineStore.Repository.Implementations
{
    public class ProductRepositoryImplementations : IProductRepository
    {
        private DataContext _context;

        public ProductRepositoryImplementations(DataContext context)
        {
            _context = context;
        }

        public async Task<dynamic> Create(Product product)
        {

            var productExists = _context.Product.SingleOrDefaultAsync(p => p.Id.Equals(product.Id));

            if (productExists != null)
            {
                return new { message = "O produto já existe" };
            }

            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Product.ToListAsync();

            return products;
        }

        public async Task<Product> GetByID(Guid id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product> Update(Guid id, Product product)
        {
            product.Id = id;

            var productExists = await _context.Product.SingleOrDefaultAsync(x => x.Id == product.Id);

            if (productExists == null)
            {
                return null;
            }

            try
            {
                _context.Entry(productExists).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync();
                var updatedProduct = await GetByID(product.Id);

                return updatedProduct;
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

        public async void Delete(Guid id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(product => product.Id == id);

            if (product != null)
            {
                try
                {
                    _context.Product.Remove(product);
                    await _context.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}