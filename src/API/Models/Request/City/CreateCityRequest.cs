using System;

namespace API.Models.Request.City
{
    public class CreateCityRequest
    {
        public Guid CountryId { get; set; }
        public string Title { get; set; }
        public float TimeOffset { get; set; }
    }
}