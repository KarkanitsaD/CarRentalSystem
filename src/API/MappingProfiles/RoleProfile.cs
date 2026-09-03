using API.Models.Request.Role;
using API.Models.Response.Role;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleModel, RoleResponse>();
            CreateMap<RoleRequest, RoleModel>();
        }
    }
}