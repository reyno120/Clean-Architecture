using Application.Recipes;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateController : Controller
    {
        [HttpPost]
        public void Create(CreateRecipeModel model)
        {
            RecipesHelper.CreateRecipe(model);
        }
    }
}
