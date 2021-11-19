using API.Models.Request.Auth;
using API.Models.Response.Auth;
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
        }
    }
}