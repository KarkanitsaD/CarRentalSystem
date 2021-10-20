using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;
using Data;
using Data.Interfaces;
using Data.Models;
using Data.Query;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, ApplicationContext context, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _context = context;
            _orderRepository = orderRepository;
        }

        public async Task<int> Count(OrderFilterModel orderFilterModel)
        {
            var filterRule = DefineFilterRule(orderFilterModel);
            return await _orderRepository.Count(filterRule);
        }

        public async Task<OrderModel> GetAsync(Guid id)
        {
            var filterRule = new FilterRule<OrderEntity, Guid>
            {
                FilterExpression = order =>
                    order.Id == id
            };

            var entity = await _orderRepository.GetAsync(filterRule);

            return _mapper.Map<OrderEntity, OrderModel>(entity);
        }

        public async Task<IList<OrderModel>> GetListAsync(OrderFilterModel orderFilterModel)
        {
            var queryParameters = new QueryParameters<OrderEntity, Guid>
            {
                FilterRule = DefineFilterRule(orderFilterModel),
                SortRule = DefineSortRule(orderFilterModel)
            };

            var entities = await _orderRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<OrderEntity>, IList<OrderModel>>(entities);
        }

        public async Task<IList<OrderModel>> GetPageListAsync(OrderFilterModel orderFilterModel)
        {
            var queryParameters = new QueryParameters<OrderEntity, Guid>
            {
                FilterRule = DefineFilterRule(orderFilterModel),
                SortRule = DefineSortRule(orderFilterModel),
                PaginationRule = new PaginationRule
                {
                    Index = orderFilterModel.PageIndex,
                    Size = orderFilterModel.PageSize
                }
            };

            var entities = await _orderRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<OrderEntity>, IList<OrderModel>>(entities);
        }

        public async Task CreateAsync(OrderModel orderModel)
        {
            var entity = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            await _orderRepository.CreateAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderModel orderModel)
        {
            var entity = _mapper.Map<OrderModel, OrderEntity>(orderModel);

            _orderRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _orderRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");

            await _context.SaveChangesAsync();
        }

        private FilterRule<OrderEntity, Guid> DefineFilterRule(OrderFilterModel orderFilterModel)
        {
            throw new NotImplementedException();
            //TODO: write logic to filter orders
        }

        private SortRule<OrderEntity, Guid> DefineSortRule(OrderFilterModel orderFilterModel)
        {
            var sortRule = new SortRule<OrderEntity, Guid>();

            if (orderFilterModel.InAscendingOrder != null)
            {
                sortRule.InAscendingOrder = (bool) orderFilterModel.InAscendingOrder;
                sortRule.SortExpression = car => car.Id;
            }

            return sortRule;
        }
    }
}
