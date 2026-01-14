using WebApiProject.Entities;

namespace WebApiProject.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateUpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
