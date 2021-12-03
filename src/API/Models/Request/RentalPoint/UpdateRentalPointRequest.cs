using System;

namespace API.Models.Request.RentalPoint
{
    public class UpdateRentalPointRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float TimeOffset { get; set; }
    }
}