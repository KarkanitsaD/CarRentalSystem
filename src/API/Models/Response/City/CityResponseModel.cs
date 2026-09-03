using System;

namespace API.Models.Response.City
{
    public class CityResponseModel
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Title { get; set; }
    }
}