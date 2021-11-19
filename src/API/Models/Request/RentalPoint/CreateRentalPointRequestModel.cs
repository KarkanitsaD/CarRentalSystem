using System;

namespace API.Models.Request.RentalPoint
{
    public class CreateRentalPointRequestModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public float? LocationX { get; set; }
        public float? LocationY { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
    }
}