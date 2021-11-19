using API.Models.Request.Car;
using API.Models.Response.Car;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<AddCarRequestModel, CarModel>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.Picture, act => act.MapFrom(src => new CarPictureModel(src.PictureBase64Content, src.PictureShortName, src.PictureExtension)));

            CreateMap<UpdateCarRequestModel, CarModel>()
                .ForMember(dest => dest.Picture, act => act.MapFrom(src => new CarPictureModel(src.PictureBase64Content, src.PictureShortName, src.PictureExtension){Id = src.ImageId, CarId = src.Id}));

            CreateMap<CarModel, CarResponseModel>();
        }
    }
}