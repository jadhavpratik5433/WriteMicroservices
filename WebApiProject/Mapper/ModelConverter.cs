using WebApiProject.DTO;

namespace WebApiProject.Mapper
{
    public static class ModelConverter
    {
        public static WebApiProject.Entities.Product DtotoModel(ProductDto model)
        {
            return new WebApiProject.Entities.Product()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId

            };
        }


        public static ProductDto ModeltoDto(WebApiProject.Entities.Product model)
        {
            return new ProductDto()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId

            };
        }
    }
}
