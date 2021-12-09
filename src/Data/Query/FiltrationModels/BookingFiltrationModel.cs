using System;

namespace Data.Query.FiltrationModels
{
    public class BookingFiltrationModel
    {
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public bool? GetCurrent { get; set; }
    }
}