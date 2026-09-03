using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class CityModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public float TimeOffset { get; set; }
        public Guid CountryId { get; set; }
        public CountryModel Country { get; set; }
        public ICollection<RentalPointModel> RentalPointEntities { get; set; }
    }
}