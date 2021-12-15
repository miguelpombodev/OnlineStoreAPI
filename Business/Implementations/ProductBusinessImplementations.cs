using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

using OnlineStore.Models;
using OnlineStore.Repository.Generic;
using OnlineStore.Repository.Implementations;

namespace OnlineStore.Business.Implementations
{
    public class ProductBusinessImplementations : IProductBusiness
    {
        private readonly IRepository<Product> _repository;

        public ProductBusinessImplementations(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<dynamic> Create(Product product)
        {

            var productExists = await _repository.Create(product);

            return productExists;
            
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _repository.GetAll();

            return products;
        }

        public async Task<Product> GetByID(Guid id)
        {
            var product = await _repository.GetByID(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product> Update(Guid id, Product product)
        {
            product.Id = id;

            var productExists = await _repository.Update(id, product);

            return productExists;
        }

        public async void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}