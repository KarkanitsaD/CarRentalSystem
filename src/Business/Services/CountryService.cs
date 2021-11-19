using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    }
}