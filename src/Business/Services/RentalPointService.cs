using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Query.RentalPoint;
using Data.Entities;
using Data.IRepositories;
using Data.Query.FiltrationModels;

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

        public async Task<(List<RentalPointModel>, int)> GetPageListAsync(RentalPointQueryModel queryModel)
        {
            var rentalPointFilter = _mapper.Map<RentalPointQueryModel, RentalPointFiltrationModel>(queryModel);
            var result = await _rentalPointRepository.GetPageListAsync(rentalPointFilter, queryModel.PageIndex, queryModel.PageSize);

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
            entityToUpdate.LocationX = rentalPointModel.LocationX;
            entityToUpdate.LocationY = rentalPointModel.LocationY;

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

            countryEntity = await _countryRepository.GetByTitleAsync(countryModel.Title);
            if (countryEntity == null)
            {
                countryEntity = await _countryRepository.CreateAsync(_mapper.Map<CountryModel, CountryEntity>(countryModel));
                cityModel.CountryId = countryEntity.Id;
                cityModel.TimeOffset = rentalPoint.TimeOffset;
                cityEntity = await _cityRepository.CreateAsync(_mapper.Map<CityModel, CityEntity>(cityModel));
            }
            else
            {
                cityEntity = await _cityRepository.GetByTitleAndCountryIdAsync(cityModel.Title, countryEntity.Id);
                if (cityEntity == null)
                {
                    cityModel.CountryId = countryEntity.Id;
                    cityEntity = await _cityRepository.CreateAsync(_mapper.Map<CityModel, CityEntity>(cityModel));
                }
            }
            return (countryEntity.Id, cityEntity.Id);
        }
    }
}