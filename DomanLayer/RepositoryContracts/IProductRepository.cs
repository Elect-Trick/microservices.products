using DomanLayer.Entities;


namespace DomanLayer.RepositoryContracts
{
    public interface IProductRepository
    {

        Task<Product?> GetProductById(int id);
        Task<Product?> AddProduct(Product product);

        Task<Product[]> GetAllProducts();
        Task<bool> DeleteProduct(Product product);

        Task<Product[]> GetProductByName(string name);
    }
}
