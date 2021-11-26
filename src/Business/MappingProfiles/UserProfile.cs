using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserModel>();

            CreateMap<UserModel, UserEntity>()
                .ForMember(src => src.RefreshToken, act => act.Ignore())
                .ForMember(src => src.Bookings, act => act.Ignore());
        }
    }
}