using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.MappingProfiles
{
    public class BookingFeedbackProfile : Profile
    {
        public BookingFeedbackProfile()
        {
            CreateMap<BookingFeedbackEntity, BookingFeedbackModel>();
            CreateMap<BookingFeedbackModel, BookingFeedbackEntity>();
        }
    }
}