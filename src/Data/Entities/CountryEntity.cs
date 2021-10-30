using System.Collections.Generic;

namespace Data.Entities
{
    public class CountryEntity : Entity
    {
        public string Title { get; set; }
        public ICollection<CityEntity> Cities { get; set; }
        public ICollection<RentalPointEntity> RentalPointEntities { get; set; }
    }
}