using Application.Recipes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class HomeController
    {
        private readonly IRecipesLogic _recipesLogic;

        public HomeController(IRecipesLogic recipesLogic)
        {
            _recipesLogic = recipesLogic;
        }


        [HttpGet]
        [Route("/GetAllRecipes")]
        public string GetAllRecipes()
        {
            var recipes = _recipesLogic.GetAll();
            return JsonConvert.SerializeObject(recipes);
        }
    }
}
