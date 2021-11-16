using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class CountryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<CityModel> Cities { get; set; }
        public ICollection<RentalPointModel> RentalPointEntities { get; set; }
    }
}