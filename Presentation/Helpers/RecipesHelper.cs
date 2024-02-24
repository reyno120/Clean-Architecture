using Application.Recipes;
using Newtonsoft.Json;

namespace Presentation.Helpers
{
    public interface IRecipesHelper
    {
        List<RecipeDTO> GetAllRecipes();
        void CreateRecipe(Models.CreateRecipeModel model);
    }

    public class RecipesHelper : IRecipesHelper
    {
        private readonly IWebApiHelper _webApiHelper;

        public RecipesHelper(IWebApiHelper webApiHelper) 
        { 
            _webApiHelper = webApiHelper;
        }

        public List<RecipeDTO> GetAllRecipes()
        {
            string route = "/GetAllRecipes";
            var api = _webApiHelper.GetApi(route);
            var recipesJson = JsonConvert.DeserializeObject(api).ToString();
            var recipes = JsonConvert.DeserializeObject<List<RecipeDTO>>(recipesJson);
            return recipes;
        }

        public void CreateRecipe(Models.CreateRecipeModel model)
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
            _webApiHelper.PostApi(route, newRecipeModel);
        }
    }
}
