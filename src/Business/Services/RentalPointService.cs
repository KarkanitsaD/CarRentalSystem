using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Query.RentalPoint;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class RentalPointService : IRentalPointService
    {
        private readonly IMapper _mapper;
        private readonly IRentalPointRepository _rentalPointRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;

        public RentalPointService(IMapper mapper, IRentalPointRepository rentalPointRepository, ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _rentalPointRepository = rentalPointRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        public async Task<RentalPointModel> GetAsync(Guid id)
        {
            var entity = await _rentalPointRepository.GetAsync(id);

            if (entity == null)
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");

            return _mapper.Map<RentalPointEntity, RentalPointModel>(entity);
        }

        public async Task<List<RentalPointModel>> GetAllAsync()
        {
            return _mapper.Map<List<RentalPointEntity>, List<RentalPointModel>>(await _rentalPointRepository.GetListAsync());
        }

        public async Task<(List<RentalPointModel>, int)> GetPageListAsync(RentalPointQueryModel queryModel)
        {
            if (!queryModel.IsValidPagination)
            {
                throw new BadRequestException("Pagination rule is not valid");
            }

            var queryParameters = new QueryParameters<RentalPointEntity>
            {
                FilterRule = GetFilterRule(queryModel),
                PaginationRule = GetPaginationRule(queryModel)
            };

            var result = await _rentalPointRepository.GetPageListAsync(queryParameters);

            var rentalPointModels = _mapper.Map<List<RentalPointEntity>, List<RentalPointModel>>(result.Items); 

            return (rentalPointModels, result.TotalItemsCount);
        }

        public async Task CreateAsync(RentalPointModel rentalPointModel)
        {
            var (countryId, cityId) = await GetCountryAndCityIdentifiersAsync(rentalPointModel);

            var entity = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);
            entity.CountryId = countryId;
            entity.CityId = cityId;

            await _rentalPointRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Guid id, RentalPointModel rentalPointModel)
        {
            if (id != rentalPointModel.Id)
                throw new BadRequestException("Check data.");

            var entityToUpdate = await _rentalPointRepository.GetAsync(id);

            if (entityToUpdate == null)
                throw new NotFoundException($"{nameof(rentalPointModel)} with id = {id} not found.");

            var (countryId, cityId) = await GetCountryAndCityIdentifiersAsync(rentalPointModel);

            entityToUpdate.CountryId = countryId;
            entityToUpdate.CityId = cityId;
            entityToUpdate.Address = rentalPointModel.Address;
            entityToUpdate.Title = rentalPointModel.Title;

            await _rentalPointRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _rentalPointRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _rentalPointRepository.DeleteAsync(entityToDelete);
        }

        private async Task<(Guid, Guid)> GetCountryAndCityIdentifiersAsync(RentalPointModel rentalPoint)
        {
            CountryEntity countryEntity;
            CityEntity cityEntity;

            var countryModel = rentalPoint.Country;
            var cityModel = rentalPoint.City;

            var countryFilterRule = new FilterRule<CountryEntity>
            {
                FilterExpression = country => country.Title == countryModel.Title
            };

            countryEntity = await _countryRepository.GetAsync(countryFilterRule);
            if (countryEntity == null)
            {
                countryEntity = await _countryRepository.CreateAsync(_mapper.Map<CountryModel, CountryEntity>(countryModel));
                cityModel.CountryId = countryEntity.Id;
                cityEntity = await _cityRepository.CreateAsync(_mapper.Map<CityModel, CityEntity>(cityModel));
            }
            else
            {
                var cityFilterRule = new FilterRule<CityEntity>
                {
                    FilterExpression = city => city.Title == cityModel.Title && city.CountryId == countryEntity.Id
                };
                cityEntity = await _cityRepository.GetAsync(cityFilterRule);
                if (cityEntity == null)
                {
                    cityModel.CountryId = countryEntity.Id;
                    cityEntity = await _cityRepository.CreateAsync(_mapper.Map<CityModel, CityEntity>(cityModel));
                }
            }

            return (countryEntity.Id, cityEntity.Id);
        }

        protected virtual FilterRule<RentalPointEntity> GetFilterRule(RentalPointQueryModel rpModel)
        {
            rpModel.NumberOfAvailableCars ??= 1;
            var filterRule = new FilterRule<RentalPointEntity>
            {
                FilterExpression = rentalPoint =>
                    (rpModel.KeyReceivingTime != null && rpModel.KeyHandOverTime != null &&
                     rentalPoint.Cars.AsQueryable().Include(car => car.Bookings)
                         .Count(car => car.Bookings.AsQueryable()
                             .Count(booking =>
                                 !(booking.KeyReceivingTime > rpModel.KeyReceivingTime && booking.KeyReceivingTime > rpModel.KeyHandOverTime ||
                                   booking.KeyHandOverTime < rpModel.KeyReceivingTime && booking.KeyHandOverTime < rpModel.KeyHandOverTime)) == 0) >= rpModel.NumberOfAvailableCars ||
                     rpModel.KeyReceivingTime == null || rpModel.KeyHandOverTime == null) &&
                    (rpModel.CountryId != null && rentalPoint.CountryId == rpModel.CountryId || rpModel.CountryId == null) &&
                    (rpModel.CityId != null && rentalPoint.CityId == rpModel.CountryId || rpModel.CityId == null)
            };

            return filterRule;
        }

        protected virtual PaginationRule GetPaginationRule(RentalPointQueryModel rpModel) => new PaginationRule
        {
            Index = rpModel.PageIndex,
            Size = rpModel.PageSize
        };
    }
}