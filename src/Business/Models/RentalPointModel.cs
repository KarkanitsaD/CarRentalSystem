using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class RentalPointModel
    {
        public Guid Id { get; set; }
        public float TimeOffset { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public float? LocationX { get; set; }
        public float? LocationY { get; set; }
        public Guid? CityId { get; set; }
        public CityModel City { get; set; }
        public Guid? CountryId { get; set; }
        public CountryModel Country { get; set; }
        public ICollection<BookingModel> Bookings { get; set; }
        public ICollection<CarModel> Cars { get; set; }
    }
}