using ECommerceApi.Application.Services;
using ECommerceApi.Infrastructure;
using ECommerceApi.Infrastructure.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using ECommerceApi.Application.Interfaces;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductPriceService, ProductPriceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductHierarchyService, ProductHierarchyService>();
builder.Services.AddScoped<IShoppingService, ShoppingService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();