using Domain.Common;

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
            var recipes = _unitOfWork.Recipes.GetAllRecipesWithDirections().ToList();

            var recipesDTO = recipes.Select(s => new RecipeDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Directions = s.Directions.Select(x => new DirectionDTO()
                {
                    Id = x.Id,
                    StepNumber = x.StepNumber,
                    Description = x.Description
                }).ToList()
            }).ToList();

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
