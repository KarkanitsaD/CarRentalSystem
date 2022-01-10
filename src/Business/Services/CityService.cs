using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.IRepositories;

namespace Business.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<List<CityModel>> GetListAsync()
        {
            return _mapper.Map<List<CityEntity>, List<CityModel>>(await _cityRepository.GetListAsync());
        }

        public async Task<CityModel> CreateAsync(CityModel cityModel)
        {
            if (await _cityRepository.GetByTitleAndCountryIdAsync(cityModel.Title, cityModel.CountryId) != null)
            {
                throw new BadRequestException($"City with title = {cityModel.Title} already exists");
            }

            var entity = await _cityRepository.CreateAsync(_mapper.Map<CityModel, CityEntity>(cityModel));

            return _mapper.Map<CityEntity, CityModel>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _cityRepository.GetAsync(id);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");
            }

            await _cityRepository.DeleteAsync(entityToDelete);
        }
    }
}