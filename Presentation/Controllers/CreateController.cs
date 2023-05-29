using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using Presentation.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateController : Controller
    {
        [HttpPost]
        public void Create([FromForm]CreateRecipeModel model)
        {
            RecipesHelper.CreateRecipe(model);
        }
    }
}
