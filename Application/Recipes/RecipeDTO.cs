//using Domain.Directions;
using Domain.Recipes;
using System;
using System.Collections.Generic;

namespace Application.Recipes
{
    public class RecipeDTO
    {
        public RecipeId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ImagePublicId { get; set; }
        public List<DirectionDTO> Directions { get; set; }
    }
}
