using System;

namespace Business.FilterModels
{
    public class RentalPointFilterModel : FilterModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime[] SelectedDates { get; set; }
        public int? NumberOfaAvailableCars { get; set; }
    }
}
