using API.Models.Request.AdditionalFacility;
using API.Models.Response.AdditionalFacility;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class AdditionalFacilityProfile : Profile
    {
        public AdditionalFacilityProfile()
        {
            CreateMap<CreateAdditionalFacilityRequest, AdditionalFacilityModel>()
                .ForMember(f => f.Id, act => act.Ignore())
                .ForMember(f => f.RentalPoint, act => act.Ignore());

            CreateMap<UpdateAdditionalFacilityRequest, AdditionalFacilityModel>()
                .ForMember(f => f.RentalPointId, act => act.Ignore())
                .ForMember(f => f.RentalPoint, act => act.Ignore());

            CreateMap<AdditionalFacilityModel, CreateAdditionalFacilityResponse>();
            CreateMap<AdditionalFacilityModel, AdditionalFacilityResponse>();
        }
    }
}