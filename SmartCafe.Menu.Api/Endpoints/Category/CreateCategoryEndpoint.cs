using FastEndpoints;
using SmartCafe.Menu.Domain;
using SmartCafe.Menu.Domain.Models.Category;
using SmartCafe.Menu.Api.Mappings.Category;
using SmartCafe.Menu.Api.Models.Category;

namespace SmartCafe.Menu.Api.Endpoints.Category;

public class CreateCategoryEndpoint : EndpointWithMapper<CreateCategoryRequest, CreateCategoryMapper>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryEndpoint(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override void Configure()
    {
        Post("categories");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCategoryRequest req, CancellationToken ct)
    {
        var createCommand = Map.ToEntity(req);
        var result = await _categoryService.AddCategoryAsync(createCommand);

        if (result.IsFailed)
        {
            if (result.Error is null)
            {
                await SendErrorsAsync();
            }
            else
            {
                if (result.Error.Status == CreateCategoryCommandErrorstatus.NameAlreadyExists)
                    ThrowError(req => req.Name, result.Error.Message);
                else if (result.Error.Status == CreateCategoryCommandErrorstatus.PriorityAlreadyExists)
                    ThrowError(req => req.Priority, result.Error.Message);
                else
                    throw new NotImplementedException($"There is no such hanler for status: {result.Error.Status}");
            }
        }

        await SendCreatedAtAsync<GetCategoryEndpoint>(
            new { CategoryId = result.Value },
            responseBody: null,
            cancellation: ct);
    }
}
