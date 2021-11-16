using System;

namespace API.Models.Response.RentalPoint
{
    public class RentalPointAddCarResponseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
    }
}