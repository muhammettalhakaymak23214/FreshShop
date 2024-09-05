using FreshShop.Business.Abstract;
using FreshShop.Business.Concrete;
using FreshShop.DataAccess.Abstract;
using FreshShop.DataAccess.Concrete;
using FreshShop.Model.Entity;
using Microsoft.SqlServer.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSingleton< IManagerBs, ManagerBs>();
builder.Services.AddSingleton<IManagerRepository, ManagerRepository>();
builder.Services.AddSingleton<IProductBs, ProductBs>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductPhotoBs, ProductPhotoBs>();
builder.Services.AddSingleton<IProductPhotoRepository, ProductPhotoRepository>();
builder.Services.AddSingleton<ICategoryBs, CategoryBs>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapAreaControllerRoute(
    name:"adminLogIn",
    areaName:"AdminPanel",
    pattern:"admin",
    defaults:new {controller = "Manager",action = "LogIn"}
    );

app.MapAreaControllerRoute(
    name: "adminDashBoard",
    areaName: "AdminPanel",
    pattern: "admin-dashboard",
    defaults: new { controller = "DashBoard", action = "Index" }
    );
app.MapAreaControllerRoute(
    name: "adminForgatPassword",
    areaName: "AdminPanel",
    pattern: "forgat-password",
    defaults: new { controller = "Manager", action = "ForgatPassword" }
    );
app.MapAreaControllerRoute(
    name: "adminManagers",
    areaName: "AdminPanel",
    pattern: "managers",
    defaults: new { controller = "Manager", action = "Index" }
    );
app.MapAreaControllerRoute(
    name: "adminUpdateManager",
    areaName: "AdminPanel",
    pattern: "update-manager",
    defaults: new { controller = "Manager", action = "Update" }
    );
app.MapAreaControllerRoute(
    name: "adminDeleteManagerPhoto",
    areaName: "AdminPanel",
    pattern: "delete-manager-photo",
    defaults: new { controller = "Manager", action = "DeletePhoto" }
    );
app.MapAreaControllerRoute(
    name: "adminDeleteManager",
    areaName: "AdminPanel",
    pattern: "delete-manager",
    defaults: new { controller = "Manager", action = "Delete" }
    );
app.MapAreaControllerRoute(
    name: "adminNewManager",
    areaName: "AdminPanel",
    pattern: "new-manager",
    defaults: new { controller = "Manager", action = "New" }
    );
app.MapAreaControllerRoute(
    name: "adminManagerPhotoUpload",
    areaName: "AdminPanel",
    pattern: "manager-photo-upload",
    defaults: new { controller = "Manager", action = "PhotoUpload" }
    );
app.MapAreaControllerRoute(
    name: "adminManagerPhotoUpload2",
    areaName: "AdminPanel",
    pattern: "manager-photo-upload2",
    defaults: new { controller = "Manager", action = "PhotoUpload2" }
    );
app.MapAreaControllerRoute(
    name: "adminProducts",
    areaName: "AdminPanel",
    pattern: "products",
    defaults: new { controller = "Product", action = "Index" }
    );
app.MapAreaControllerRoute(
    name: "adminNewProduct",
    areaName: "AdminPanel",
    pattern: "new-product",
    defaults: new { controller = "Product", action = "New" }
    );
app.MapAreaControllerRoute(
    name: "adminDeleteProduct",
    areaName: "AdminPanel",
    pattern: "delete-product",
    defaults: new { controller = "Product", action = "Delete" }
    );
app.MapAreaControllerRoute(
    name: "adminProductPhotoUpload",
    areaName: "AdminPanel",
    pattern: "product-photo-upload",
    defaults: new { controller = "Product", action = "PhotoUpload" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
