using System.Collections.Generic;
using AutoMapper;
using Business.IServices;
using Business.Models.City;
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

        public IEnumerable<CityModel> GetList()
        {
            return _mapper.Map<IEnumerable<CityEntity>, IEnumerable<CityModel>>(_cityRepository.GetList());
        }
    }
}