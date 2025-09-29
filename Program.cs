using ASPCourceEmpty.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPostcardsRepository, PostcardRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// builder.Services.AddDbContext<PostcardDBContext>((optionsBuilder) =>
// {
//     optionsBuilder.UseNpgsql(builder.Configuration["ConnectionStrings:PostcardsDBCon"]);
// });

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<PostcardDBContext>();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.UseSession();

app.MapRazorPages();
//seed initial data
DBInitializer.Seed(app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<PostcardDBContext>());

app.Run();
