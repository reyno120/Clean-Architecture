using Application.Recipes;
using Newtonsoft.Json;

namespace Presentation.Helpers
{
    public static class RecipesHelper
    {
        public static List<RecipeDTO> GetAllRecipes()
        {
            string route = "/GetAllRecipes";
            var api = WebApiHelper.GetApi(route);
            var recipesJson = JsonConvert.DeserializeObject(api).ToString();
            var recipes = JsonConvert.DeserializeObject<List<RecipeDTO>>(recipesJson);
            return recipes;
        }

        public static void CreateRecipe(CreateRecipeModel model)
        {
            string route = "/CreateRecipe";
            WebApiHelper.PostApi(route, model);
        }
    }
}
