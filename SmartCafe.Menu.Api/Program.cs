using FastEndpoints;
using SmartCafe.Menu.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddFastEndpoints();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseFastEndpoints(b =>
{
    b.Endpoints.RoutePrefix = "api";
});
app.Run();
