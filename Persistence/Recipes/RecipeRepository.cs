using Domain.Recipes;
using Persistence.Common;

namespace Persistence.Recipes
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationContext context) : base(context) 
        { 
        }
    }
}
