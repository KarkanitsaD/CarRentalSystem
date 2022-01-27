using System;

namespace Business.SingleR.EventModels
{
    public class NewCityModel
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Title { get; set; }
    }
}