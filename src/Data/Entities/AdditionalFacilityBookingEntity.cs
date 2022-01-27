using System;

namespace Data.Entities
{
    public class AdditionalFacilityBookingEntity : Entity
    {
        public Guid BookingId { get; set; }
        public BookingEntity Booking { get; set; }
        public Guid AdditionalFacilityId { get; set; }
        public AdditionalFacilityEntity AdditionalFacility { get; set; }
    }
}