using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class AdditionalFacilityProfile : Profile
    {
        public AdditionalFacilityProfile()
        {
            CreateMap<AdditionalFacilityEntity, AdditionalFacilityModel>()
                .ReverseMap();
        }
    }
}