using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class RentalPointModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? LocationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public ICollection<BookingModel> Bookings { get; set; }
        public ICollection<CarModel> Cars { get; set; }
    }
}