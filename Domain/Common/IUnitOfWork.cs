using Domain.Directions;
using Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IRecipeRepository Recipes { get; }
        IDirectionRepository Directions { get; }
        int Complete();
    }
}
