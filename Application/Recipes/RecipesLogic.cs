﻿using Domain.Common;

namespace Application.Recipes
{
    public class RecipesLogic : IRecipesLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecipesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<RecipeDTO> GetAll()
        {
            var recipes = _unitOfWork.Recipes.GetAll().ToList();
            var directions = _unitOfWork.Directions.GetAll().ToList();

            var recipesDTO = new List<RecipeDTO>();
            foreach(var recipe in recipes)
            {
                var recipeDirections = directions
                    .Where(w => w.RecipeId == recipe.Id)
                    .OrderBy(s => s.StepNumber)
                    .ToList();

                var recipeDTO = new RecipeDTO()
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Directions = recipeDirections
                };

                recipesDTO.Add(recipeDTO);
            }
            return recipesDTO;
        }

        public Guid Create(CreateRecipeModel createRecipeModel)
        {
            //var newRecipe = _unitOfWork.Recipes.Add(createRecipeModel);
            //return newRecipe.Id;
            return Guid.Empty;
        }
    }
}