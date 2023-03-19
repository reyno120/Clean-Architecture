using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recipes
{
    public interface IRecipesLogic
    {
        public List<RecipeDTO> GetAll();
    }
}
