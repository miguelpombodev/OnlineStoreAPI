using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Models;
using OnlineStore.Repository.Generic;



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

            if (productExists == null)
            {
                return null;
            }

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

        public async Task<bool> Delete(Guid id)
        {
            var isProductDeleted = await _repository.Delete(id);

            if (isProductDeleted == false)
            {
                return false;
            }

            return true;
        }
    }
}