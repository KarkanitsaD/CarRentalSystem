using System;

namespace Business.SignalR.EventModels
{
    public class NewCityModel
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Title { get; set; }
    }
}