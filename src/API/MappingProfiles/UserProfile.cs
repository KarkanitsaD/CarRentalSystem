using API.Models.Request.Auth;
using API.Models.Response.Auth;
using AutoMapper;
using Business.Models;
using Data.Entities;

namespace API.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Bookings, act => act.MapFrom(src => src.Bookings))
                .ReverseMap();

            CreateMap<LoginRequestModel, LoginModel>();
            CreateMap<LoginSuccessModel, LoginResponseModel>();
        }
    }
}