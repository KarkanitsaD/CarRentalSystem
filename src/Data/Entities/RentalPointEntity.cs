using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class RentalPointEntity : Entity
    {
        public string Title { get; set; }
        public Guid? LocationId { get; set; }
        public LocationEntity Location { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
    }
}