using Domain.Recipes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Recipes;
using System.Data.Common;
using Testcontainers.MsSql;

// https://learn.microsoft.com/en-us/ef/core/testing/
// https://learn.microsoft.com/en-us/ef/core/testing/testing-without-the-database
// In-Memory testing is typically discouraged because you are not testing against an actual production like database
// Many databases often have features that don't work with an In-Memory database
// Better off using Moq to mock out your repositories & dependencies. Writing tests will be easier, execution will be faster, and it will provide the same value
// as using an In-Memory Databse

// A much better approach would be to use a real test database that simulates what your production database will look like.

namespace IntegrationTests
{
    public class InMemoryIntegrationTests
    {
        private readonly DbContextOptions<ApplicationContext> _contextOptions;

        public InMemoryIntegrationTests() 
        {
            _contextOptions = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("InMemoryIntegrationTests")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            using var context = new ApplicationContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var recipe = Recipe.Create("In-Memory Recipe", "Integration Test Using In-Memory Database", Guid.Empty);
            recipe.AddStep(recipe.Id, 1, "Test Step 1");

            context.AddRange(recipe);
            context.SaveChanges();
        }

        [Fact]
        public void GetAllRecipesWithDirections_InMemoryDatabase()
        {
            // Arrange
            using var context = new ApplicationContext(_contextOptions);
            var repository = new RecipeRepository(context);

            // Act
            var data = repository.GetAllRecipesWithDirections();

            // Assert
            Assert.Single(data);
            Assert.Equal("In-Memory Recipe", data.ToList().First().Name);
        }
    }
}