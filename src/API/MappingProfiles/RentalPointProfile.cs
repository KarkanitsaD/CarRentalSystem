using API.Models.Response.RentalPoint;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class RentalPointProfile : Profile
    {
        public RentalPointProfile()
        {
            CreateMap<RentalPointModel, RentalPointResponseModel>();
        }
    }
}