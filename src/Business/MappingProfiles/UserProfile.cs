using AutoMapper;
using Business.Models;
using Business.Query;
using Business.Query.User;
using Data.Entities;
using Data.Query.FiltrationModels;

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

            CreateMap<UserQueryModel, UserFiltrationModel>();
        }
    }
}