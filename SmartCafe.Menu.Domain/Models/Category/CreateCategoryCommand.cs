namespace SmartCafe.Menu.Domain.Models.Category;

public sealed class CreateCategoryCommand
{
    public required string Name { get; set; }
    public int Priority { get; set; }
}
