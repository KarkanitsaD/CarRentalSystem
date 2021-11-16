using System;

namespace Business.Query
{
    public class RentalPointQueryModel : QueryModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime[] SelectedDates { get; set; }
        public int? NumberOfAvailableCars { get; set; }
    }
}