using Domain.Directions;
using Persistence.Common;

namespace Persistence.Directions
{
    public class DirectionRepository : Repository<Direction>, IDirectionRepository
    {
        public DirectionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
