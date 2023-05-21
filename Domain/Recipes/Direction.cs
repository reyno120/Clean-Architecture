
namespace Domain.Recipes
{
    public class Direction
    {
        private const short _maxStepNumber = 15;
        public DirectionId Id { get; private set; }
        public RecipeId RecipeId { get; private set; }
        public short StepNumber { get; init; }
        public string Description { get; init; }
        private Direction(RecipeId recipeId, short stepNumber, string description)
        {
            Id = new DirectionId(Guid.NewGuid());
            RecipeId = recipeId;
            StepNumber = stepNumber;
            Description = description;
        }

        public static Direction? Create(RecipeId recipeId, short stepNumber, string description)
        {
            if(recipeId.Value.Equals(Guid.Empty))
                return null;

            if (string.IsNullOrEmpty(description))
                return null;

            if (stepNumber > _maxStepNumber || stepNumber == null)
                return null;

            return new Direction(recipeId, stepNumber, description);
        }
    }
}
