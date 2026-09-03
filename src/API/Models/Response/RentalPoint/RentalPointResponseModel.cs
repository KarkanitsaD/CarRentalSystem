using System;

namespace API.Models.Response.RentalPoint
{
    public class RentalPointResponseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public float? LocationX { get; set; }
        public float? LocationY { get; set; }
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        public Guid CityId { get; set; }
        public string City { get; set; }
    }
}