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
        Task<Product?> AddProduct(ProductDTO productDTO);
        Task<Product?> UpdateProduct(Product product);
        Task<Product?> DeleteProduct(Product productDTO);
        Task<Product?> GetProductById(int id);
        Task<Product?> GetProductByName(string name);

    }
}
