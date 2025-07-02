using Multishop.Catalog.Dtos.CategoryDtos;

namespace Multishop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        //Task ile asenkron yapı kullanılacak.
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
