using System;

namespace API.Models.Request.AdditionalFacility
{
    public class CreateAdditionalFacilityRequest
    {
        public decimal Price { get; set; }
        public string Title { get; set; }
        public Guid RentalPointId { get; set; }
    }
}