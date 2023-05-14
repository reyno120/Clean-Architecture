using Domain.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recipes
{
    public class CreateRecipeModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Directions> Directions { get; set; }
    }
    public class Directions
    {
        public short StepNumber { get; set; }
        public string Direction { get; set; }
    }
}
