using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFirstProjectMVC1.Data;
using MyFirstProjectMVC1.Interfaces;
using MyFirstProjectMVC1.Mapping;
using MyFirstProjectMVC1.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyFirstProjectMVC1ContextConnection") ?? throw new InvalidOperationException("Connection string 'MyFirstProjectMVC1ContextConnection' not found.");

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMapper<MyFirstProjectMVC1.Entities.Category, MyFirstProjectMVC1.Models.CategoryModel>, CategoryMapper>();



builder.Services.AddDbContext<MyFirstProjectMVC1Context>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyFirstProjectMVC1Context>();;

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();


app.Run();

