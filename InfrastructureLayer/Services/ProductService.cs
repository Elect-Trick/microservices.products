using ApplicationLayer.DTOS;
using ApplicationLayer.ServiceContracts;
using DomanLayer.Entities;
using DomanLayer.RepositoryContracts;

namespace InfrastructureLayer.Services;

    public class ProductService : IProductService
    {

    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product?> AddProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> DeleteProduct(Product productDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductById(int id)
        {
            Product? product = await _productRepository.GetProductById(id);

        if (product == null)
        {
            return null;
        }
            return product;
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
