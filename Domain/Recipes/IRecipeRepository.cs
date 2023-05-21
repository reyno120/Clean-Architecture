using Domain.Common;

namespace Domain.Recipes
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        IEnumerable<Recipe> GetAllRecipesWithDirections();
    }
}
