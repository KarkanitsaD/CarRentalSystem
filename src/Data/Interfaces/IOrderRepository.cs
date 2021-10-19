using System;
using Data.Models;

namespace Data.Interfaces
{
    public interface IOrderRepository : IRepository<OrderEntity, Guid>
    {

    }
}
