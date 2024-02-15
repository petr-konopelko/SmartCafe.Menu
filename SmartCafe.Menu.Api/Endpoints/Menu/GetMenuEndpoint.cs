using FastEndpoints;
using SmartCafe.Menu.Api.Models.Menu;

namespace SmartCafe.Menu.Api.Endpoints.Menu;

public class GetMenuEndpoint : EndpointWithoutRequest<MenuResponse>
{
    public override void Configure()
    {
        Get("menu");
        AllowAnonymous();
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return SendAsync(
            new MenuResponse()
            {
                Id = Guid.NewGuid(),
                Name = "chicken nugets",
                Description = "some crispy nugets chicken",
                Category = "poultry",
            },
            cancellation: ct);
    }
}
