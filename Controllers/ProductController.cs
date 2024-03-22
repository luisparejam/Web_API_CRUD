using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_CRUD.Models;
using Web_API_CRUD.Services.ProductService;

namespace Web_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        //[HttpGet]
        //[Route("{id}")]
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            var result = await _productService.GetSingleProduct(id);
            if (result == null)
                return NotFound("Sorry, but this product doesn't exist.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var result = await _productService.AddProduct(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var result = await _productService.UpdateProduct(request);
            if (result == null)
                return NotFound("Sorry, but this product doesn't exist.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result is null)
                return NotFound("Sorry, but this product doesn't exist.");

            return Ok(result);
        }

    }
}