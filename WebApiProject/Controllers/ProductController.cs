using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProduct();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> CreateUpdate([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest();

            var result = await _productService.CreateUpdateProductAsync(productDto);
            return Ok(result);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);

            if (!isDeleted)
                return NotFound(new { message = "Product not found" });

            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
