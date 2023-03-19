using Domain.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Recipes
{
    public class RecipeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Direction> Directions { get; set; }
}
}
