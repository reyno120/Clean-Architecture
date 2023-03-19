using Domain.Common;
using Domain.Recipes;
using Persistence.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Recipes = new RecipeRepository(_context);
            Directions = new IDirectionRepository(_context);
        }
        public IRecipeRepository Recipes { get; private set; }
        public IDirectionRepository Directions { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose() 
        {
            _context.Dispose();
        }
    }
}
