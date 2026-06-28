using DomanLayer.Entities;
using DomanLayer.RepositoryContracts;
using InfrastructureLayer.DatabaseContext;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace InfrastructureLayer.Repositories;
    public class ProductRepository : IProductRepository
    {
        private readonly EfDbContext _context;
        public ProductRepository(EfDbContext context)
        {
            _context = context; 
        }

    public async Task<Product?> AddProduct(Product product)
    {
            Product? existingProduct = _context.Products.FirstOrDefault(p => p.ProductName == product.ProductName);
        if (existingProduct != null)    {
            return null;
        }
        else
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }

    public  Task<Product?> GetProductById(int id)
     {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductID == id);
            return Task.FromResult(product);
     }

    public Task<Product[]> GetAllProducts()
    {
        Product[] products = _context.Products.ToArray();
        return Task.FromResult(products);
    }

    public async Task<bool> DeleteProduct(Product product)
    {
         _context.Products.Remove(product);
        int rowsAffected = await _context.SaveChangesAsync(); 
        if(rowsAffected > 0)
        {

            return true;
        }

        return false;
    }

    public async Task<Product[]> GetProductByName(string name)
    {

       Product[] products = _context.Products
    .Where(p => EF.Functions.Like(p.ProductName, $"%{name}%"))
    .ToArray();
        //Product[] products =  _context.Products.Where(p => p.ProductName.Contains(name)).ToArray();
        if (products == null || products.Length == 0)
        {
            return null;
        }
        return products;  
    }

}
