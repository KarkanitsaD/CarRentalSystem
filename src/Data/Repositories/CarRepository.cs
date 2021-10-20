using System;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class CarRepository : Repository<CarEntity, Guid>, ICarRepository
    {
        public CarRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
