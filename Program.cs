using ASPCourceEmpty.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPostcardsRepository, PostcardRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// builder.Services.AddDbContext<PostcardDBContext>((optionsBuilder) =>
// {
//     optionsBuilder.UseNpgsql(builder.Configuration["ConnectionStrings:PostcardsDBCon"]);
// });

builder.Services.AddDbContext<PostcardDBContext>();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

//seed initial data
DBInitializer.Seed(app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<PostcardDBContext>());

app.Run();
