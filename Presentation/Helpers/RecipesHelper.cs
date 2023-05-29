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

        public static void CreateRecipe(Models.CreateRecipeModel model)
        {
            var newDirectionsModel = model.Directions.Select(s => new Directions
            {
                StepNumber = s.StepNumber,
                Direction = s.Direction
            }).ToList();

            

            var newRecipeModel = new CreateRecipeModel()
            {
                Name = model.Name,
                Description = model.Description,
                Directions = newDirectionsModel,
                Image = model.Image != null ? model.Image.GetByteArray() : null
        };

            string route = "/CreateRecipe";
            WebApiHelper.PostApi(route, newRecipeModel);
        }
    }
}
