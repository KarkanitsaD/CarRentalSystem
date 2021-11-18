using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryEntity, CountryModel>();

            CreateMap<CountryModel, CountryEntity>()
                .ForMember(src => src.Cities, act => act.Ignore())
                .ForMember(src => src.RentalPoints, act => act.Ignore());
        }
    }
}