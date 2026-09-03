using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleEntity, RoleModel>().ReverseMap();
        }
    }
}