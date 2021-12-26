using DatabaseServer.Database;
using DatabaseServer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<CityRepository>();
builder.Services.AddTransient<OrderRepository>();
builder.Services.AddTransient<ServiceRepository>();
builder.Services.AddTransient<ServiceTaskRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<PostgresConnection>(options => options.UseNpgsql(connection));

var app = builder.Build();

app.MapControllers();

app.Run();
