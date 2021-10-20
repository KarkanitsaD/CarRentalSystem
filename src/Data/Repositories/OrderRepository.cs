using System;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class OrderRepository : Repository<OrderEntity, Guid>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
