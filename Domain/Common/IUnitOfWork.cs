using Domain.Recipes;

namespace Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IRecipeRepository Recipes { get; }
        int Complete();
    }
}
