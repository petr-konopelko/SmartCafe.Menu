using FastEndpoints;
using SmartCafe.Menu.Domain.Models.Category;
using SmartCafe.Menu.Api.Models.Category;

namespace SmartCafe.Menu.Api.Mappings.Category;

public class CreateCategoryMapper : RequestMapper<CreateCategoryRequest, CreateCategoryCommand>
{
    public override CreateCategoryCommand ToEntity(CreateCategoryRequest r)
    {
        return new CreateCategoryCommand
        {
            Name = r.Name,
            Priority = r.Priority,
        };
    }
}
