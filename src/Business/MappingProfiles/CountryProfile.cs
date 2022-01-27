using AutoMapper;
using Business.Models;
using Business.SingleR.EventModels;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryEntity, CountryModel>();

            CreateMap<CountryEntity, NewCountryModel>();
            CreateMap<CityEntity, NewCityModel>();

            CreateMap<CountryModel, CountryEntity>()
                .ForMember(src => src.Cities, act => act.Ignore())
                .ForMember(src => src.RentalPoints, act => act.Ignore());
        }
    }
}