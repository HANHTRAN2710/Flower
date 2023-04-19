using Flower.Areas.Admin.Services;
using Flower.Controllers;
using Flower.Models;
using Flower.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddScoped<HomeService, HomeServiceImpl>();
builder.Services.AddScoped<CategoryService, CategoryServiceImpl>();

builder.Services.AddScoped<Flower.Areas.Admin.Services.ProductService, Flower.Areas.Admin.Services.ProductServiceImpl>();
builder.Services.AddScoped<Flower.Areas.Admin.Services.CategoryService, Flower.Areas.Admin.Services.CategoryServiceImpl>();
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddHttpContextAccessor(); //add cart la phai co cai dong nay 
builder.Services.AddSession();//session




var app = builder.Build();
app.UseStaticFiles(); //cau hinh cho hinh anh sau khi tao folder wwwroot
app.UseSession();//session
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.MapControllerRoute(
    name: "default1",
    pattern: "{area}/{controller}/{action}");
app.Run();
