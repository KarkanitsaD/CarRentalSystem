using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Models;

namespace Business.Interfaces
{
    public interface IOrderService
    {
        Task<int> Count(OrderFilterModel orderFilterModel);
        Task<OrderModel> GetAsync(int id);
        Task<IList<OrderModel>> GetListAsync(OrderFilterModel orderFilterModel);
        Task<IList<OrderModel>> GetPageListAsync(OrderFilterModel orderFilterModel);
        Task CreateAsync(OrderModel orderModel);
        Task UpdateAsync(OrderModel orderModel);
        Task DeleteAsync(Guid id);
    }
}
