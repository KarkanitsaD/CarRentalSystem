using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class CityEntity : Entity
    {
        public string Title { get; set; }
        public float TimeOffset { get; set; }
        public Guid CountryId { get; set; }
        public CountryEntity Country { get; set; }
        public ICollection<RentalPointEntity> RentalPointEntities { get; set; }
    }
}