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
            CreateMap<RefreshTokenSuccessModel, RefreshTokenResponseModel>();
            CreateMap<LoginRequest, LoginRegisterModel>();
            CreateMap<RegisterRequest, RegisterModel>();
            CreateMap<LoginSuccessModel, LoginResponseModel>();
            CreateMap<UserModel, UserResponse>();
            CreateMap<UpdateUserRequest, UserModel>();
            CreateMap<CreateUserRequest, CreateUserModel>();
        }
    }
}