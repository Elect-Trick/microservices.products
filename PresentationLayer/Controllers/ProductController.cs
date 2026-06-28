using ApplicationLayer.DTOS;
using ApplicationLayer.ServiceContracts;
using DomanLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace PresentationLayer.Controllers;

    [ApiController]
    [Route("api/[controller]/")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<ProductDTO> _productValidator;
    public ProductsController(IProductService productService, IValidator<ProductDTO> productValidator)
        {
            _productService = productService;
            _productValidator = productValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
        // Implementation for getting all products
        Product[] products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("search/productId/{id}")]
        public async Task<Product?> GetProductById(int id)
        {
          
            Product? product = await _productService.GetProductById(id);
            if (product == null)
            {
                return null;
            }
           
            return product;
        }

        [HttpGet("search/{productName}")]
        public async Task<ActionResult<Product?>> GetProductByName(string productName)
        {
          
            Product[] products = await _productService.GetProductByName(productName);
            if (products == null || products.Length == 0)
            {
                return NotFound(new
                {
                    Title = "Product not found",
                    Status = 404,
                    Message = $"No product found with Name {productName}."
                });
        }
        
           
            return Ok(products);
        }


        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(ProductDTO productDto)
        {


        var validationResult = await _productValidator.ValidateAsync(productDto);

        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Title = "Validation failed",
                Status = 400,
                Errors = validationResult.Errors
                             .Select(e => e.ErrorMessage)
                             .ToList()
            });
        }

        Product? product = await _productService.AddProduct(productDto);
        if (product == null) {
            return BadRequest(new
            {
                Title = "Product Creation failed",
                Status = 400,
                Message = "Product with the same name already exists."
            });

        }
            return Ok(product);
        }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        Product? product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound(new
            {
                Title = "Product not found",
                Status = 404,
                Message = $"No product found with ID {id}."
            });
        }

        bool success = await _productService.DeleteProduct(product);
        if (!success)
        {
            return BadRequest(new
            {
                Title = "Product Deletion failed",
                Status = 400,
                Message = "Failed to delete the product."
            });
        }
        return Ok(new { Message = "Product deleted successfully." });
    }
}

          
   

