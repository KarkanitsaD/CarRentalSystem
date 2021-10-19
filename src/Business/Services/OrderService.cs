using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        public Task<int> Count(OrderFilterModel orderFilterModel)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<OrderModel>> GetListAsync(OrderFilterModel orderFilterModel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<OrderModel>> GetPageListAsync(OrderFilterModel orderFilterModel)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(OrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
