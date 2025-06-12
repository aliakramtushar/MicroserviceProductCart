using Microsoft.EntityFrameworkCore;
using CartService.Data;
using CartService.Repositories;
using CartService.Clients;
using CartService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CartDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddHttpClient<ProductClient>(c =>
{
    c.BaseAddress = new(builder.Configuration["ProductServiceUrl"]);
});
builder.Services.AddScoped<CartServiceImpl>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger(); app.UseSwaggerUI();
app.MapControllers();
app.Run();
