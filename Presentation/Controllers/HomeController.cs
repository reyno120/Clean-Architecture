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
            return new List<RecipeDTO>()
            {
                new RecipeDTO() { Name = "Docker Test" }
            };
            //var recipes = RecipesHelper.GetAllRecipes(); 
            //return recipes;
        }
    }
}
