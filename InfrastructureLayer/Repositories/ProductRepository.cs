using DomanLayer.Entities;
using DomanLayer.RepositoryContracts;
using InfrastructureLayer.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories;
    public class ProductRepository : IProductRepository
    {
        private readonly EfDbContext _context;
        public ProductRepository(EfDbContext context)
        {
            _context = context; 
        }
        public  Task<Product?> GetProductById(int id)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.ProductID == id);
            return Task.FromResult(product);
        }
    }
