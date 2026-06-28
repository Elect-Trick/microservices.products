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

    public async Task<Product?> AddProduct(ProductDTO product)
        {
        Product _product = new Product(); 
        _product.ProductName = product.ProductName;
        _product.UnitPrice = product.UnitPrice;
        _product.Category = product.Category;
        _product.QuantityInStock = product.QuantityInStock;

        Product? result = await _productRepository.AddProduct(_product);
        return result;
    }

    public async Task<Product[]> GetAllProducts()
    {
       Product[] result = await _productRepository.GetAllProducts();
        return result;
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

        public async Task<Product[]> GetProductByName(string name)
        {
            Product[] products = await _productRepository.GetProductByName(name);
            if (products == null || products.Length == 0)
            {
                return new Product[0];
            }
            return products; 
    
        }

        public Task<Product?> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(Product product) { 

        bool success = await _productRepository.DeleteProduct(product);
        return success;

    }

}
