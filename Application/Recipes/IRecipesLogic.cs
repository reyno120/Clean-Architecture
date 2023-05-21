
using Domain.Recipes;

namespace Application.Recipes
{
    public interface IRecipesLogic
    {
        public List<RecipeDTO> GetAll();

        public void Create(CreateRecipeModel createRecipeModel);
    }
}
