using System;
using Data.Interfaces;
using Data.Models;

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
