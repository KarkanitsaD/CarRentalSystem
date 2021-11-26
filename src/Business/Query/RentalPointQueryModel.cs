using System;

namespace Business.Query
{
    public class RentalPointQueryModel : QueryModel
    {
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public DateTime CarPickUpDate { get; set; }
        public DateTime CarReturnDate { get; set; }
        public int? NumberOfAvailableCars { get; set; }
    }
}