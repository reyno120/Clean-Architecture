using Domain.Common;
using Domain.Recipes;
using Persistence;
using Persistence.Common;
using Persistence.Recipes;
using Microsoft.EntityFrameworkCore;
using Application.Recipes;
using Application.Common;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IRecipesLogic, RecipesLogic>();
builder.Services.AddTransient<ICloudinaryHelper, CloudinaryHelper>();

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// If using Https, configure using https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-8.0
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
