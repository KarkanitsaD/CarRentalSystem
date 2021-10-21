using System;

namespace Business.Models
{
    public class AdditionalFacilityModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}