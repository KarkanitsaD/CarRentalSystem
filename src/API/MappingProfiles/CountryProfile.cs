using API.Models.Response.Country;
using AutoMapper;
using Business.Models;

namespace API.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryModel, CountryResponseModel>();
        }
    }
}