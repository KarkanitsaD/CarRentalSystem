using AutoMapper;
using Business.Models;
using Business.Query.RentalPoint;
using Data.Entities;
using Data.Query.FiltrationModels;

namespace Business.MappingProfiles
{
    public class RentalPointProfile : Profile
    {
        public RentalPointProfile()
        {
            CreateMap<RentalPointEntity, RentalPointModel>()
                .ForMember(src => src.TimeOffset, act => act.Ignore());

            CreateMap<RentalPointModel, RentalPointEntity>()
                .ForMember(src => src.City, act => act.Ignore())
                .ForMember(src => src.Country, act => act.Ignore())
                .ForMember(src => src.Bookings, act => act.Ignore())
                .ForMember(src => src.Cars, act => act.Ignore());

            CreateMap<RentalPointQueryModel, RentalPointFiltrationModel>();
        }
    }
}