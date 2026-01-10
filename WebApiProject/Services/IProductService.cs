using WebApiProject.DTO;

namespace WebApiProject.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
