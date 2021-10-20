using AutoMapper;
using Business.Models;
using Data.Models;

namespace Business.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleEntity, RoleModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, act => act.MapFrom(src => src.Title));
        }
    }
}
