using DomanLayer.Entities;


namespace DomanLayer.RepositoryContracts
{
    public interface IProductRepository
    {

        Task<Product?> GetProductById(int id);
    }
}
