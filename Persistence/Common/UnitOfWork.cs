using Domain.Common;
using Domain.Recipes;
using Persistence.Recipes;

namespace Persistence.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IRecipeRepository Recipes { get; private set; }
        public UnitOfWork(ApplicationContext context, IRecipeRepository recipes)
        {
            _context = context;
            Recipes = recipes;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
