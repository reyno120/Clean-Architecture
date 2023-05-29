using Application.Common;
using Domain.Common;
using Domain.Recipes;

namespace Application.Recipes
{
    public class RecipesLogic : IRecipesLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryHelper _cloudinaryHelper;
        public RecipesLogic(IUnitOfWork unitOfWork, ICloudinaryHelper cloudinaryHelper)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryHelper = cloudinaryHelper;
        }
        public List<RecipeDTO> GetAll()
        {
            var recipes = _unitOfWork.Recipes.GetAllRecipesWithDirections().ToList();

            var recipesDTO = recipes.Select(s => new RecipeDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImagePublicId = s.ImagePublicId,
                Directions = s.Directions.Select(x => new DirectionDTO()
                {
                    Id = x.Id,
                    StepNumber = x.StepNumber,
                    Description = x.Description
                }).ToList()
            }).ToList();

            return recipesDTO;
        }

        public void Create(CreateRecipeModel createRecipeModel)
        {
            Guid? newImagePublicId = null;
            if(createRecipeModel.Image != null)
            {
                newImagePublicId = Guid.NewGuid();
                _cloudinaryHelper.UploadImage(newImagePublicId.ToString(), "recipes", createRecipeModel.Image);
            }

            var newRecipe = Recipe.Create(createRecipeModel.Name, createRecipeModel.Description, newImagePublicId);
            foreach(var direction in createRecipeModel.Directions)
            {
                newRecipe.AddStep(newRecipe.Id, direction.StepNumber, direction.Direction);
            }

            _unitOfWork.Recipes.CreateNewRecipe(newRecipe);
        }
    }
}
