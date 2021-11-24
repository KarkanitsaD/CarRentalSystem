using System.Linq;
using API.Models.Request.Auth;
using API.Models.Request.User;
using API.Models.Response.Auth;
using API.Models.Response.User;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginRequestModel, LoginModel>();
            CreateMap<LoginSuccessModel, LoginResponseModel>();
            CreateMap<UserModel, UserResponse>()
                .ForMember(src => src.Roles, act => act.MapFrom(dest => dest.Roles.Select(x => x.Title)));
            CreateMap<UpdateUserRequest, UserModel>();
        }
    }
}