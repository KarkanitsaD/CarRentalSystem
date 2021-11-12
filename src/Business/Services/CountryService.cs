using System.Collections.Generic;
using AutoMapper;
using Business.IServices;
using Business.Models.Country;
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

        public IEnumerable<CountryModel> GetList()
        {
            return _mapper.Map<IEnumerable<CountryEntity>, IEnumerable<CountryModel>>(_countryRepository.GetList());
        }
    }
}