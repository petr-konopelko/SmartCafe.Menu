using SmartCafe.Menu.Domain.Models;
using SmartCafe.Menu.Domain.Models.Category;

namespace SmartCafe.Menu.Domain;

public interface ICategoryService
{
    Task<CategoryDto?> GetCategoryAsync(Guid categoryId);
    Task<Result<Guid, ErrorResult<CreateCategoryCommandErrorstatus>>> AddCategoryAsync(CreateCategoryCommand createCategoryCommand);
}
