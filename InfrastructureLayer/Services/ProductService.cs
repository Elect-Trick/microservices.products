using ApplicationLayer.DTOS;
using ApplicationLayer.ServiceContracts;
using DomanLayer.Entities;

namespace InfrastructureLayer.Services;

    public class ProductService : IProductService
    {
        public Task<Product?> AddProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> DeleteProduct(Product productDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
