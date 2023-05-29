using Domain.Recipes;

namespace Application.Recipes
{
    public class RecipeDTO
    {
        public RecipeId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ImagePublicId { get; set; }
        public List<DirectionDTO> Directions { get; set; }
    }
}
