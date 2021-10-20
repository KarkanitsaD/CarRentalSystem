using System.Collections.Generic;

namespace Business.Models
{
    public class RentalPointModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? LocationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public virtual ICollection<BookingModel> Bookings { get; set; }
        public virtual ICollection<CarModel> Cars { get; set; }
    }
}
