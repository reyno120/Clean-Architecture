
namespace Application.Recipes
{
    public interface IRecipesLogic
    {
        public List<RecipeDTO> GetAll();

        public Guid Create(CreateRecipeModel createRecipeModel);
    }
}
