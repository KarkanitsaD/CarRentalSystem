using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Query.RentalPoint;
using Business.SingleR.EventModels;
using Business.SingleR.Hubs;
using Data.Entities;
using Data.IRepositories;
using Data.Query.FiltrationModels;
using Microsoft.AspNetCore.SignalR;

namespace Business.Services
{
    public class RentalPointService : IRentalPointService
    {
        private readonly IMapper _mapper;
        private readonly IRentalPointRepository _rentalPointRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IHubContext<LocationHub> _locationHub;

        public RentalPointService(IMapper mapper, IRentalPointRepository rentalPointRepository, ICountryRepository countryRepository, ICityRepository cityRepository, IHubContext<LocationHub> locationHub)
        {
            _mapper = mapper;
            _rentalPointRepository = rentalPointRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _locationHub = locationHub;
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
            var countryId = await GetCountryIdOrCreate(rentalPointModel.Country.Title);
            var cityId = await GetCityIdOrCreate(countryId, rentalPointModel.City.Title,
                rentalPointModel.City.TimeOffset);

            var entity = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);
            entity.CountryId = countryId;
            entity.CityId = cityId;

            await _rentalPointRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Guid id, RentalPointModel rentalPointModel)
        {
            if (id != rentalPointModel.Id)
                throw new BadRequestException("Ids from route and model are not equal.");

            var entityToUpdate = await _rentalPointRepository.GetAsync(id);

            if (entityToUpdate == null)
                throw new NotFoundException($"{nameof(rentalPointModel)} with id = {id} not found.");

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

        private async Task<Guid> GetCountryIdOrCreate(string countryTitle)
        {
            var country = await _countryRepository.GetByTitleAsync(countryTitle);
            if (country == null)
            {
                country = new CountryEntity { Title = countryTitle };
                country = await _countryRepository.CreateAsync(country);

                var newCountryModel = _mapper.Map<CountryEntity, NewCountryModel>(country);
                await _locationHub.Clients.All.SendAsync("addCountry", newCountryModel);
            }

            return country.Id;
        }

        private async Task<Guid> GetCityIdOrCreate(Guid countryId, string title, float timeOffset)
        {
            var city = await _cityRepository.GetByTitleAndCountryIdAsync(title, countryId);
            if (city == null)
            {
                city = new CityEntity { Title = title, CountryId = countryId, TimeOffset = timeOffset };
                city = await _cityRepository.CreateAsync(city);

                var newCityModel = _mapper.Map<CityEntity, NewCityModel>(city);
                await _locationHub.Clients.All.SendAsync("addCity", newCityModel);
            }

            return city.Id;
        }
    }
}