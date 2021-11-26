using API.Models.Request.City;
using API.Models.Response.City;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityModel, CityResponseModel>();
            CreateMap<CreateCityRequest, CityModel>();
        }
    }
}