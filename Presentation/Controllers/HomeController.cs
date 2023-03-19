using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        //private readonly IGetRecipeName _query;

        //public HomeController(IGetRecipeName query)
        //{
        //    _query = query;
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public string GettingRecipeName()
        //{
        //    var recipeName = _query.GetRecipename();
        //    return JsonConvert.SerializeObject(recipeName);
        //}

        [HttpGet]
        public string GettingRecipeName()
        {
            var recipeName = _query.GetRecipename();
            return JsonConvert.SerializeObject(recipeName);
        }
    }
}
