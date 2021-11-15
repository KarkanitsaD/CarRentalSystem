using AutoMapper;
using Business.Models;
using Data.Entities;

namespace API.MappingProfiles
{
    public class CarPictureProfile : Profile
    {
        public CarPictureProfile()
        {
            CreateMap<CarPictureEntity, CarPictureModel>();
        }
    }
}