using ApplicationLayer.ServiceContracts;
using DomanLayer.Entities;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.Controllers;

    [ApiController]
    [Route("api/[controller]/")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("productId/{id}")]
        public async Task<Product?> GetProductById(int id)
        {
          
            Product? product = await _productService.GetProductById(id);
            if (product == null)
            {
                return null;
            }
           
            return product;
        }
    }

