using System;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IOrderRepository : IRepository<OrderEntity, Guid>
    {

    }
}
