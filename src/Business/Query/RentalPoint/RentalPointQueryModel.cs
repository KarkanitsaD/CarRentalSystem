using System;

namespace Business.Query.RentalPoint
{
    public class RentalPointQueryModel : QueryModel
    {
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public DateTime? KeyReceivingTime { get; set; }
        public DateTime? KeyHandOverTime { get; set; }
        public int? NumberOfAvailableCars { get; set; }
    }
}