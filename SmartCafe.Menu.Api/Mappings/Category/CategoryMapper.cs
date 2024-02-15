using FastEndpoints;
using SmartCafe.Menu.Domain.Models.Category;
using SmartCafe.Menu.Api.Models.Category;

namespace SmartCafe.Menu.Api.Mappings.Category;

public class CategoryMapper : ResponseMapper<CategoryResponse, CategoryDto>
{
    public override CategoryResponse FromEntity(CategoryDto e)
    {
        return new CategoryResponse
        {
            Id = e.Id,
            Name = e.Name,
            Priority = e.Priority,
        };
    }
}
