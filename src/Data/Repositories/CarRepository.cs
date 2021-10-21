using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class CarRepository : BaseRepository<CarEntity>, ICarRepository
    {
        public CarRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}