using Domain.Recipes;
using Microsoft.EntityFrameworkCore;
using Persistence.Common;

namespace Persistence.Recipes
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        protected readonly ApplicationContext _context;
        public RecipeRepository(ApplicationContext context) : base(context)
        { 
            _context = context;
        }
        public IEnumerable<Recipe> GetAllRecipesWithDirections()
        {
            return _context.Recipes.Include(s => s.Directions).AsNoTracking().ToList();
        }

        public void CreateNewRecipe(Recipe recipe)
        {
            try
            {
                _context.Recipes.Add(recipe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
