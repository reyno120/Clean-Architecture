using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using Application.Recipes;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        //[Route("[action]")]
        public IEnumerable<RecipeDTO> Get()
        {
            var recipes = RecipesHelper.GetAllRecipes(); 
            return recipes;
        }

        [HttpPost]
        //[Route("/CreateRecipe")]
        public void CreateRecipe(CreateRecipeModel model)
        {
            RecipesHelper.CreateRecipe(model);
        }
    }
}
