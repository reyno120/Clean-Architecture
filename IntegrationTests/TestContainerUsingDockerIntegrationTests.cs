using Application.Recipes;
using Domain.Recipes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Persistence;
using Persistence.Recipes;
using System.Data.Common;
using Testcontainers.MsSql;


// https://learn.microsoft.com/en-us/ef/core/testing/testing-with-the-database
// https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0

namespace IntegrationTests
{
    //public class TestContainerUsingDockerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    //{
    //    private readonly WebApplicationFactory<Program> _factory;

    //    public TestContainerUsingDockerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    //    {
    //        _factory = factory;
    //    }


    //[Fact]
    //public async Task GetAllRecipesWithDirections_DockerTestContainer()
    //{
    //    // Arrange
    //    using (var scope = _factory.Services.CreateScope())
    //    {
    //        var scopedServices = scope.ServiceProvider;
    //        var db = scopedServices.GetRequiredService<ApplicationContext>();
    //        CreateTestData(db);
    //    }

    //    var httpClient = _factory.CreateClient();

    //    // Act
    //    var response = await httpClient.GetAsync("/GetAllRecipes");
    //    var data = await response.Content.ReadAsStringAsync();
    //    var recipes = JsonConvert.DeserializeObject<List<RecipeDTO>>(data);

    //    // Assert
    //    response.EnsureSuccessStatusCode();
    //    Assert.Single(recipes);
    //    Assert.Equal("In-Memory Recipe", recipes.ToList().First().Name);
    //}

    //private void CreateTestData(ApplicationContext context)
    //{
    //    var recipe = Recipe.Create("In-Memory Recipe", "Integration Test Using In-Memory Database", Guid.Empty);
    //    recipe.AddStep(recipe.Id, 1, "Test Step 1");

    //    context.AddRange(recipe);
    //    context.SaveChanges();
    //}
    //}

    //public class CustomWebApplicationFactory<TProgram>
    //: WebApplicationFactory<TProgram> where TProgram : class
    //{
    //    protected override void ConfigureWebHost(IWebHostBuilder builder)
    //    {
    //        builder.ConfigureServices(services =>
    //        {
    //            var dbContextDescriptor = services.SingleOrDefault(
    //                d => d.ServiceType ==
    //                    typeof(DbContextOptions<ApplicationContext>));

    //            services.Remove(dbContextDescriptor);

    //            var dbConnectionDescriptor = services.SingleOrDefault(
    //                d => d.ServiceType ==
    //                    typeof(DbConnection));

    //            services.Remove(dbConnectionDescriptor);

    //            services.AddDbContext<ApplicationContext>(options =>
    //            {
    //                options.UseInMemoryDatabase("Test");
    //            });
    //        });

    //        builder.UseEnvironment("Development");
    //    }
    //}








    public sealed class MsSqlTests : IAsyncLifetime
    {
        // Move this to a BaseIntegrationTest class so we can use it throughout all our integration test classes
        // Look into Respawn for resetting data between tests
        private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
            .Build();

        public Task InitializeAsync()
        {
            return _msSqlContainer.StartAsync();
        }

        public Task DisposeAsync()
        {
            return _msSqlContainer.DisposeAsync().AsTask();
        }

        public sealed class TestContainerUsingDockerIntegrationTests : IClassFixture<MsSqlTests>, IDisposable
        {
            private readonly WebApplicationFactory<Program> _webApplicationFactory;

            private readonly HttpClient _httpClient;

            public TestContainerUsingDockerIntegrationTests(MsSqlTests fixture)
            {
                var clientOptions = new WebApplicationFactoryClientOptions();
                clientOptions.AllowAutoRedirect = false;

                _webApplicationFactory = new CustomWebApplicationFactory(fixture);
                _httpClient = _webApplicationFactory.CreateClient(clientOptions);

                Task.Run(async () => await InitializeDB()).Wait();
            }

            private async Task InitializeDB()
            {
                // Initializing and seeding our database. Normally would use db migrations instead or a custom built image w/ prepopulated data
                using (var scope = _webApplicationFactory.Services.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationContext>();

                    var rawSQL = await File.ReadAllLinesAsync("../../../setup.txt");
                    foreach(var line in rawSQL)
                    {
                        await db.Database.ExecuteSqlRawAsync(line);
                    }
                    
                }
            }


            [Fact]
            public async Task GetAllRecipesWithDirections_DockerTestContainer()
            {
                // Arrange


                // Act
                var response = await _httpClient.GetAsync("/GetAllRecipes");
                var data = await response.Content.ReadAsStringAsync();
                var recipes = JsonConvert.DeserializeObject<List<RecipeDTO>>(data);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Single(recipes);
                Assert.Equal("Docker TestContainer Recipe", recipes.ToList().First().Name);
            }

            private void CreateTestData(ApplicationContext context)
            {
                var recipe = Recipe.Create("Docker TestContainer Recipe", "Integration Test Using TestContainers Library", Guid.Empty);
                recipe.AddStep(recipe.Id, 1, "Test Step 1");

                context.AddRange(recipe);
                context.SaveChanges();
            }


            public void Dispose()
            {
                _webApplicationFactory.Dispose();
            }

            private sealed class CustomWebApplicationFactory : WebApplicationFactory<Program>
            {
                private readonly string _connectionString;

                public CustomWebApplicationFactory(MsSqlTests fixture)
                {
                    _connectionString = fixture._msSqlContainer.GetConnectionString();
                }

                protected override void ConfigureWebHost(IWebHostBuilder builder)
                {
                    builder.ConfigureServices(services =>
                    {
                        services.Remove(services.SingleOrDefault(service => typeof(DbContextOptions<ApplicationContext>) == service.ServiceType));
                        services.Remove(services.SingleOrDefault(service => typeof(DbConnection) == service.ServiceType));
                        services.AddDbContext<ApplicationContext>((_, option) => option.UseSqlServer(_connectionString));
                    });
                }
            }
        }
    }
}
