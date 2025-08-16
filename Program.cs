using ecommerce_api;
using AppConfig = ecommerce_api.Config.AppConfig;
using ecommerce_api.Controllers;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.OpenApi.Models;
using ecommerce_api.Config;
using ecommerce_api.Repositories.Interfaces;
using ecommerce_api.Repositories.Classes;
using ecommerce_api.Services.Interfaces;
using ecommerce_api.Services.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IAppConfig, AppConfig>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("EComSwag", new OpenApiInfo
    {
        Title = "EComSwag",
        Version = "v1"
        // Or if you want to explicitly use OpenAPI 3.0.0
        // Version = "3.0.0" 
    });
});

builder.Services.AddCors(option =>
{
    option.AddPolicy("EcommPolicy", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();
app.UseCors();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        // This should match the name used in SwaggerDoc (e.g., "v1")
        c.SwaggerEndpoint("/swagger/EComSwag/swagger.json", "EComSwag");
        // If you were using a virtual path or behind a proxy, you might use:
        // c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
    });
    
}
app.MapControllers();
app.Run();

