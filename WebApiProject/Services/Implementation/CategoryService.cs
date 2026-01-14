using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Entities;
using WebApiProject.Services;

namespace WebApiProject.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDbContext _context;

        public CategoryService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> CreateUpdateCategoryAsync(Category category)
        {
            if (category.Id > 0)
            {
                _context.Categories.Update(category);
            }
            else
            {
                _context.Categories.Add(category);
            }

            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
