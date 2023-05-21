using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using Application.Recipes;
using Domain.Recipes;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RecipeDTO> Get()
        {
            var recipes = RecipesHelper.GetAllRecipes(); 
            return recipes;
        }
    }
}
