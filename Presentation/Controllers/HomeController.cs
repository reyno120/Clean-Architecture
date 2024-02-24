using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using Application.Recipes;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IRecipesHelper _recipesHelper;

        public HomeController(IRecipesHelper recipesHelper)
        {
            _recipesHelper = recipesHelper;
        }

        [HttpGet]
        public IEnumerable<RecipeDTO> Get()
        {
            var recipes = _recipesHelper.GetAllRecipes();
            return recipes;
        }
    }
}
