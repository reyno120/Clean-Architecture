using Domain.Common;
using Domain.Recipes;
using Domain.Directions;
//using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Common;
using Persistence.Recipes;
using Persistence.Directions;
using Application.Recipes;
//using Persistence.Directions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ApplicationContext>(options =>
//options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")
//    //,b => b.MigrationAssembly(typeof(ApplicationContext).Assembly.FullName)
//    )
//);
//builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
//builder.Services.AddTransient<IDirectionRepository, DirectionRepository>();
//builder.Services.AddTransient<IRecipesLogic, RecipesLogic>();
//Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
