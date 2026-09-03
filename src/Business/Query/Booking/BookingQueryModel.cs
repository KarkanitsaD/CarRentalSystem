using System;

namespace Business.Query.Booking
{
    public class BookingQueryModel : QueryModel
    {
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public bool? GetCurrent { get; set; }
        public Guid UserId { get; set; }
    }
}