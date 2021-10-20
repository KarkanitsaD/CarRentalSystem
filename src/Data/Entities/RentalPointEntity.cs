using System.Collections.Generic;

namespace Data.Entities
{
    public class RentalPointEntity : Entity<int>
    {
        public string Title { get; set; }
        public int? LocationId { get; set; }
        public LocationEntity Location { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
    }
}