using System;

namespace API.Models.Request.City
{
    public class CreateCityRequest
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Title { get; set; }
    }
}