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
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly ICarRepository _carRepository;

        public CarService(IMapper mapper, ApplicationContext context, ICarRepository carRepository)
        {
            _mapper = mapper;
            _context = context;
            _carRepository = carRepository;
        }

        public async Task<int> Count(CarFilterModel carFilterModel)
        {
            var filterRule = DefineFilterRule(carFilterModel);
            return await _carRepository.Count(filterRule);
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            var filterRule = new FilterRule<CarEntity, Guid>
            {
                FilterExpression = car =>
                    car.Id == id
            };

            var entity = await _carRepository.GetAsync(filterRule);

            return _mapper.Map<CarEntity, CarModel>(entity);
        }

        public async Task<IList<CarModel>> GetListAsync(CarFilterModel carFilterModel)
        {
            var queryParameters = new QueryParameters<CarEntity, Guid>
            {
                FilterRule = DefineFilterRule(carFilterModel),
                SortRule = DefineSortRule(carFilterModel)
            };

            var entities = await _carRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<CarEntity>, IList<CarModel>>(entities);
        }

        public async Task<IList<CarModel>> GetPageListAsync(CarFilterModel carFilterModel)
        {
            var queryParameters = new QueryParameters<CarEntity, Guid>
            {
                FilterRule = DefineFilterRule(carFilterModel),
                SortRule = DefineSortRule(carFilterModel),
                PaginationRule = new PaginationRule
                {
                    Index = carFilterModel.PageIndex,
                    Size = carFilterModel.PageSize
                }
            };

            var entities = await _carRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<CarEntity>, IList<CarModel>>(entities);
        }

        public async Task CreateAsync(CarModel carModel)
        {
            var entity = _mapper.Map<CarModel, CarEntity>(carModel);

            await _carRepository.CreateAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarModel carModel)
        {
            var entity = _mapper.Map<CarModel, CarEntity>(carModel);

            _carRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async  Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _carRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");


            await _context.SaveChangesAsync();
        }

        private FilterRule<CarEntity, Guid> DefineFilterRule(CarFilterModel carFilterModel)
        {
            var filterRule = new FilterRule<CarEntity, Guid>
            {
                FilterExpression = car =>
                    (!string.IsNullOrEmpty(carFilterModel.CarBrand) && car.CarBrand == carFilterModel.CarBrand ||
                     string.IsNullOrEmpty(carFilterModel.CarBrand)) &&
                    (carFilterModel.FuelConsumptionPerHundredKilometers != null &&
                     car.FuelConsumptionPerHundredKilometers ==
                     carFilterModel.FuelConsumptionPerHundredKilometers ||
                     carFilterModel.FuelConsumptionPerHundredKilometers == null) &&
                    (carFilterModel.NumberOfSeats != null && car.NumberOfSeats == carFilterModel.NumberOfSeats ||
                     carFilterModel.NumberOfSeats == null) &&
                    (!string.IsNullOrEmpty(carFilterModel.TransmissionType) &&
                     car.TransmissionType == carFilterModel.TransmissionType ||
                     string.IsNullOrEmpty(carFilterModel.TransmissionType)) &&
                    (!string.IsNullOrEmpty(carFilterModel.Color) && car.Color == carFilterModel.Color ||
                     string.IsNullOrEmpty(carFilterModel.Color))
            };

            return filterRule;
        }

        private SortRule<CarEntity, Guid> DefineSortRule(CarFilterModel carFilterModel)
        {
            var sortRule = new SortRule<CarEntity, Guid>();

            if (carFilterModel.InAscendingOrder != null)
            {
                sortRule.InAscendingOrder = (bool)carFilterModel.InAscendingOrder;
                sortRule.SortExpression = car => car.Id;
            }

            return sortRule;
        }
    }
}
