using Domain.Common;
using Domain.Exceptions;
using System.Runtime.InteropServices;

namespace Domain.Recipes
{
    public class Recipe : IAggregateRoot<RecipeId>
    {
        public RecipeId Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Guid? ImagePublicId { get; private set; }

        public List<Direction> Directions { get; private set; }

        public static Recipe Create(string name, string description, Guid? imagePublicId)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            if (string.IsNullOrEmpty(description))
                return null;

            var recipe = new Recipe()
            {
                Id = new RecipeId(Guid.NewGuid()),
                Name = name,
                Description = description,
                Directions = new List<Direction>(),
                ImagePublicId = imagePublicId == Guid.Empty ? null : imagePublicId
            };

            return recipe;
        }

        public void AddStep(RecipeId recipeId, short stepNumber, string description)
        {
            if (Directions.Where(w => w.StepNumber == stepNumber).Count() > 0)
                return;

            var step = Direction.Create(recipeId, stepNumber, description);
            Directions.Add(step);
        }
    }
}
