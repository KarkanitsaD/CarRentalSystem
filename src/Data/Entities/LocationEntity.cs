using System;

namespace Data.Entities
{
    public class LocationEntity : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Guid? RentalPointId { get; set; }
        public RentalPointEntity RentalPoint { get; set; }
    }
}