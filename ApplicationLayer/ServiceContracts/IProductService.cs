using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.DTOS;
using DomanLayer.Entities;

namespace ApplicationLayer.ServiceContracts
{
    public interface IProductService
    {
        Task<Product?> AddProduct(ProductDTO product);
        Task<Product?> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product productDTO);
        Task<Product?> GetProductById(int id);
        Task<Product[]> GetProductByName(string name);
        Task<Product[]> GetAllProducts();

    }
}
