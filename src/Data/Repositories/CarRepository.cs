using System;
using Data.Interfaces;
using Data.Models;

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
