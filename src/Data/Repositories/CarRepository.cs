using System;
using Data.Entities;
using Data.Interfaces;
using Data.IRepositories;

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