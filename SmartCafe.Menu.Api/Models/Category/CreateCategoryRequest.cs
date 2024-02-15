namespace SmartCafe.Menu.Api.Models.Category;

public sealed class CreateCategoryRequest
{
    public required string Name { get; set; }

    public int Priority { get; set; }
}
