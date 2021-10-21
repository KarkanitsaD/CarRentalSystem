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
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, act => act.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Roles, act => act.MapFrom(src => src.Roles))
                .ForMember(dest => dest.Bookings, act => act.MapFrom(src => src.Bookings))
                .ReverseMap();
        }
    }
}