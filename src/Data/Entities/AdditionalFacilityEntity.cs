using System.Collections.Generic;

namespace Data.Entities
{
    public class AdditionalFacilityEntity : Entity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; }
    }
}