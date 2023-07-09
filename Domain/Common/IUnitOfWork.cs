using Domain.Recipes;

namespace Domain.Common
{
    public interface IUnitOfWork
    {
        IRecipeRepository Recipes { get; }
        int Save();
    }
}
