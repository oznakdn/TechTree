
namespace TechTree.Application.Services
{
    public interface ICategoryService
    {
        Task<CategoriesDto> GetAll();
        Task<CategoryDto> Get(int id);
        Task Add(CreateCategoryDto createCategoryDto);
        Task Update(UpdateCategoryDto updateCategoryDto);
    }
}
