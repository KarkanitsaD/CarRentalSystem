using System.Collections.Generic;

namespace Data.Entities
{
    public class RentalPointEntity : Entity<int>
    {
        public string Title { get; set; }
        public int? LocationId { get; set; }
        public virtual LocationEntity Location { get; set; }

        public virtual ICollection<BookingEntity> Bookings { get; set; }
        public virtual ICollection<CarEntity> Cars { get; set; }
    }
}