using Domain.Exceptions;
using Domain.Recipes;

namespace Domain.UnitTests.Recipes
{
    public class RecipesTests
    {
        Recipe _recipe;

        public RecipesTests()
        {
            _recipe = Recipe.Create("Test", "Test", null);
        }

        [Trait("Recipe", "Recipes")]
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Create_NullOrEmptyName_ReturnsNull(string name)
        {
            //Arrange
            string description = "Test";
            Guid publicImageId = Guid.Empty;

            //Act
            var newRecipe = Recipe.Create(name, description, publicImageId);

            //Assert
            Assert.Null(newRecipe);
        }

        [Trait("Recipe", "Recipes")]
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Create_NullOrEmptyDescription_ReturnsNull(string description)
        {
            //Arrange
            string name = "Test";
            Guid publicImageId = Guid.Empty;

            //Act
            var newRecipe = Recipe.Create(name, description, publicImageId);

            //Assert
            Assert.Null(newRecipe);
        }

        [Trait("Recipe", "Recipes")]
        [Fact]
        public void Create_RecipeWithImage_ReturnsNewRecipeWithImage()
        {
            //Arrange
            string name = "Test";
            string description = "Test";
            Guid publicImageId = Guid.NewGuid();

            //Act
            var newRecipe = Recipe.Create(name, description, publicImageId);

            //Assert
            Assert.NotNull(newRecipe.Id);
            Assert.Equal(name, newRecipe.Name);
            Assert.Equal(description, newRecipe.Description);
            Assert.Equal(publicImageId, newRecipe.ImagePublicId);
        }

        [Trait("Recipe", "Recipes")]
        [Theory]
        [InlineData(null)]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void Create_RecipeWithNoImage_ReturnsNewRecipeWithNoImage(string publicImageId)
        {
            //Arrange
            string name = "Test";
            string description = "Test";
            Guid? imageId = publicImageId == null ? null : Guid.Parse(publicImageId);

            //Act
            var newRecipe = Recipe.Create(name, description, imageId);

            //Assert
            Assert.NotNull(newRecipe.Id);
            Assert.Equal(name, newRecipe.Name);
            Assert.Equal(description, newRecipe.Description);
            Assert.Null(newRecipe.ImagePublicId);
        }

        [Trait("Recipe", "Recipes")]
        [Fact]
        public void AddStep_NewStep_IsSuccessful()
        {
            //Arrange
            RecipeId recipeId = new RecipeId(Guid.NewGuid());
            string description = "Test";
            short stepNumber = 1;

            //Act
            _recipe.AddStep(recipeId, stepNumber, description);

            //Assert
            Assert.Equal(1, _recipe.Directions.Count());
            Assert.Equal(recipeId, _recipe.Directions[0].RecipeId);
            Assert.Equal(description, _recipe.Directions[0].Description);
            Assert.Equal(stepNumber, _recipe.Directions[0].StepNumber);
        }

        [Trait("Recipe", "Recipes")]
        [Fact]
        public void AddStep_MultipleSteps_IsSuccessful()
        {
            //Arrange
            RecipeId recipeId_1 = new RecipeId(Guid.NewGuid());
            string description_1 = "Test 1";
            short stepNumber_1 = 1;

            RecipeId recipeId_2 = new RecipeId(Guid.NewGuid());
            string description_2 = "Test 2";
            short stepNumber_2 = 2;

            //Act
            _recipe.AddStep(recipeId_1, stepNumber_1, description_1);
            _recipe.AddStep(recipeId_2, stepNumber_2, description_2);

            //Assert
            Assert.Equal(2, _recipe.Directions.Count());
            Assert.Equal(recipeId_1, _recipe.Directions[0].RecipeId);
            Assert.Equal(description_1, _recipe.Directions[0].Description);
            Assert.Equal(stepNumber_1, _recipe.Directions[0].StepNumber);

            Assert.Equal(recipeId_2, _recipe.Directions[1].RecipeId);
            Assert.Equal(description_2, _recipe.Directions[1].Description);
            Assert.Equal(stepNumber_2, _recipe.Directions[1].StepNumber);
        }

        [Trait("Recipe", "Recipes")]
        [Fact]
        public void AddStep_AlreadyExistingStep_DoesNotOverwriteExistingStep()
        {
            //Arrange
            RecipeId recipeId = new RecipeId(Guid.NewGuid());
            string existingDescription = "Test Existing";
            string newDescription = "Test New";
            short stepNumber = 1;

            //Act
            _recipe.AddStep(recipeId, stepNumber, existingDescription);
            _recipe.AddStep(recipeId, stepNumber, newDescription);

            //Assert
            Assert.Equal(1, _recipe.Directions.Count());
            Assert.Equal(recipeId, _recipe.Directions[0].RecipeId);
            Assert.Equal(existingDescription, _recipe.Directions[0].Description);
            Assert.Equal(stepNumber, _recipe.Directions[0].StepNumber);
        }
    }
}