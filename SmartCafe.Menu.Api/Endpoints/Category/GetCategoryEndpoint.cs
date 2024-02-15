using FastEndpoints;
using SmartCafe.Menu.Api.Mappings.Category;
using SmartCafe.Menu.Domain;
using SmartCafe.Menu.Api.Models.Category;

namespace SmartCafe.Menu.Api.Endpoints.Category;

public class GetCategoryEndpoint : EndpointWithoutRequest<CategoryResponse, CategoryMapper>
{
    private readonly ICategoryService _categoryService;

    public GetCategoryEndpoint(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override void Configure()
    {
        Get("categories/{CategoryId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var categoryId = Route<Guid>("CategoryId");

        var category = await _categoryService.GetCategoryAsync(categoryId);

        if (category is null)
            await SendNotFoundAsync(ct);

        await SendMapped(category);
    }
}
