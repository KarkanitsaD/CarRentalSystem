using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class RentalPointEntity : Entity
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public float? LocationX { get; set; }
        public float? LocationY { get; set; }
        public Guid CityId { get; set; }
        public CityEntity City { get; set; }
        public Guid CountryId { get; set; }
        public CountryEntity Country { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
        public ICollection<AdditionalFacilityEntity> AdditionalFacilities { get; set; }
    }
}