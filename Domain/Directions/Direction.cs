using Domain.Common;

namespace Domain.Directions
{
    public class Direction : IEntity
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }

        public short StepNumber { get; set; }

        public string Description { get; set; }
    }
}
