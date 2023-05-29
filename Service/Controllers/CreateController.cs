using Application.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CreateController
    {
        private readonly IRecipesLogic _recipesLogic;

        public CreateController(IRecipesLogic recipesLogic)
        {
            _recipesLogic = recipesLogic;
        }

        [HttpPost]
        [Route("/CreateRecipe")]
        public void CreateRecipe(CreateRecipeModel createRecipe)
        {
            _recipesLogic.Create(createRecipe);
        }
    }
}
