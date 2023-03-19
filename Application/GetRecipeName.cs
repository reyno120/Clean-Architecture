using Domain.Common;

namespace Application
{
    public class GetRecipeName : IGetRecipeName
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetRecipeName(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string GetRecipename()
        {
            var recipes = _unitOfWork.Recipes.GetAll().ToList();
            return recipes[0].Name;
        }

    }
}