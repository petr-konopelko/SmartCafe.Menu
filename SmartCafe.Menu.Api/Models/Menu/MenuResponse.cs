namespace SmartCafe.Menu.Api.Models.Menu;

public sealed class MenuResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Category { get; set; }
}
