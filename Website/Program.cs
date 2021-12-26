using Common;
using Website.Database;
using Website.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<AccountRepository>();
builder.Services.AddDbContext<PostgresContext>(options => options.UseNpgsql(connection));
builder.Services.AddControllersWithViews();

var JwtConfig = builder.Configuration.GetSection("JWTAuth");
builder.Services.Configure<JWTData>(JwtConfig);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
