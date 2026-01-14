using Microsoft.AspNetCore.Mvc;
using WebApiProject.Entities;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound(new { message = "Category not found" });

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> CreateUpdate([FromBody] Category category)
        {
            if (category == null)
                return BadRequest();

            var result = await _categoryService.CreateUpdateCategoryAsync(category);
            return Ok(result);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _categoryService.DeleteCategoryAsync(id);

            if (!isDeleted)
                return NotFound(new { message = "Category not found" });

            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
