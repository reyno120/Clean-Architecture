using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;
using Presentation.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateController : Controller
    {
        private readonly IRecipesHelper _recipesHelper;

        public CreateController(IRecipesHelper recipesHelper)
        {
            _recipesHelper = recipesHelper;
        }

        [HttpPost]
        public void Create([FromForm]CreateRecipeModel model)
        {
            _recipesHelper.CreateRecipe(model);
        }
    }
}
