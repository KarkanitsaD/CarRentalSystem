using System;

namespace API.Models.Request.AdditionalFacility
{
    public class UpdateAdditionalFacilityRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}