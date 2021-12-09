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
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryModel>> GetListAsync()
        {
            return _mapper.Map<List<CountryEntity>, List<CountryModel>>(await _countryRepository.GetListAsync());
        }

        public async Task<CountryModel> CreateAsync(string title)
        {
            if (await _countryRepository.GetByTitleAsync(title) != null)
            {
                throw new BadRequestException($"Country with title = {title} already exists");
            }

            var entity = await _countryRepository.CreateAsync(new CountryEntity() { Title = title });

            return _mapper.Map<CountryEntity, CountryModel>(entity);
        }

        public async Task DeleteAsync(Guid countryId)
        {
            var entityToDelete = await _countryRepository.GetAsync(countryId);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {countryId} not found.");
            }

            await _countryRepository.DeleteAsync(entityToDelete);
        }
    }
}