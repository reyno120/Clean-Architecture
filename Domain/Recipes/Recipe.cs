using Domain.Common;

namespace Domain.Recipes
{
    public class Recipe : IAggregateRoot<RecipeId>
    {
        public RecipeId Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Guid? ImagePublicId { get; private set; }

        public List<Direction> Directions { get; private set; }

        public static Recipe Create(string name, string description)
        {
            var recipe = new Recipe()
            {
                Id = new RecipeId(Guid.NewGuid()),
                Name = name,
                Description = description,
                Directions = new List<Direction>()
            };

            return recipe;
        }

        public void AddStep(RecipeId recipeId, short stepNumber, string description)
        {
            var step = Direction.Create(recipeId, stepNumber, description);
            Directions.Add(step);
        }
    }
}
