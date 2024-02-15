namespace SmartCafe.Menu.Api.Models.Category;

public class CategoryResponse
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public int Priority { get; set; }
}
