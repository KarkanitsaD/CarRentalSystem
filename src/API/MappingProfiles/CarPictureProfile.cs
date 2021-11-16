﻿using System;
using API.Models.Request.Car;
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

            CreateMap<AddCarRequestModel, CarPictureModel>()
                .ForMember(dest => dest.Content,
                    act => act.MapFrom(src => Convert.FromBase64String(src.PictureBase64Content)))
                .ForMember(dest => dest.ShortName, act => act.MapFrom(src => src.PictureShortName))
                .ForMember(dest => dest.Extension, act => act.MapFrom(src => src.PictureExtension));
        }
    }
}