using Domain.Exceptions;
using Domain.Recipes;

namespace Domain.UnitTests.Recipes
{
    public class DirectionTests
    {
        [Trait("Recipe", "Directions")]
        [Theory]
        [InlineData(null)]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public void Create_NullOrEmptyRecipeId_ThrowArgumentNullOrEmptyException(string recipeIdString)
        {
            //Arrange
            string description = "Test";
            short stepNumber = 1;
            RecipeId? recipeId = recipeIdString == null ? null : new RecipeId(Guid.Parse(recipeIdString));

            //Act
            var act = () => Direction.Create(recipeId, stepNumber, description);

            //Assert
            Assert.Throws<ArgumentNulOrEmptyException>(act);
        }

        [Trait("Recipe", "Directions")]
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Create_NullOrEmptyDescription_ReturnsNull(string description)
        {
            //Arrange
            RecipeId recipeId = new RecipeId(Guid.NewGuid());
            short stepNumber = 1;

            //Act
            var direction = Direction.Create(recipeId, stepNumber, description);

            //Assert
            Assert.Null(direction);
        }

        [Trait("Recipe", "Directions")]
        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(16)]
        public void Create_StepNumberNotInRange_ReturnsNull(short stepNumber)
        {
            //Arrange
            RecipeId recipeId = new RecipeId(Guid.NewGuid());
            string description = "Test";    

            //Act
            var direction = Direction.Create(recipeId, stepNumber, description);

            //Assert
            Assert.Null(direction);
        }

        [Trait("Recipe", "Directions")]
        [Fact]
        public void Create_NewDirection_ReturnsDirection()
        {
            //Arrange
            RecipeId recipeId = new RecipeId(Guid.NewGuid());
            string description = "Test";
            short stepNumber = 1;

            //Act
            var direction = Direction.Create(recipeId, stepNumber, description);

            Assert.NotNull(direction.Id);
            Assert.NotEqual(Guid.Empty, direction.Id.Value);
            Assert.Equal(recipeId, direction.RecipeId);
            Assert.Equal(description, direction.Description);
            Assert.Equal(stepNumber, direction.StepNumber);
        }
    }
}
