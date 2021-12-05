using System;

namespace API.Models.Request.Booking
{
    public class CreateBookingRequest
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }
        public Guid CarId { get; set; }
        public Guid RentalPointId { get; set; }
        public DateTime KeyReceivingTime { get; set; }
        public DateTime KeyHandOverTime { get; set; }
        public DateTime BookingTime { get; set; }
    }
}