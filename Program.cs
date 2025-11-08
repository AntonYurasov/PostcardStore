using System.Text.Json.Serialization;
using ASPCourceEmpty.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }
);
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

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<PostcardDBContext>();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
//seed initial data
DBInitializer.Seed(app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<PostcardDBContext>());

app.Run();
