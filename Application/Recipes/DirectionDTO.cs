using Domain.Recipes;

namespace Application.Recipes
{
    public class DirectionDTO
    {
        public DirectionId Id { get; set; }
        public short StepNumber { get; set; }
        public string Description { get; set; }
    }
}
