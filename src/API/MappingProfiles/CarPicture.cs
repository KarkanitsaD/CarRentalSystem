using AutoMapper;
using Business.Models;
using Data.Entities;

namespace API.MappingProfiles
{
    public class CarPicture : Profile
    {
        public CarPicture()
        {
            CreateMap<CarPictureEntity, CarPictureModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.Extension, act => act.MapFrom(src => src.Extension))
                .ForMember(dest => dest.Content, act => act.MapFrom(src => src.Content))
                .ForMember(dest => dest.ShortName, act => act.MapFrom(src => src.ShortName));
        }
    }
}