using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityEntity, CityModel>();

            CreateMap<CityModel, CityEntity>()
                .ForMember(src => src.Country, act => act.Ignore())
                .ForMember(src => src.RentalPointEntities, act => act.Ignore());
        }
    }
}