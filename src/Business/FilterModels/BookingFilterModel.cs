using System;

namespace Business.FilterModels
{
    public class BookingFilterModel : FilterModel
    {
        public Guid? UserId { get; set; }
        public int? RentalPointId { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? MaximumPrice { get; set; }
    }
}
