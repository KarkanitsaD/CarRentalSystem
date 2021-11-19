using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class CarPictureProfile : Profile
    {
        public CarPictureProfile()
        {
            CreateMap<PictureEntity, CarPictureModel>();

            CreateMap<CarPictureModel, CarPictureEntity>()
                .ForMember(src => src.Car, act => act.Ignore());
        }
    }
}