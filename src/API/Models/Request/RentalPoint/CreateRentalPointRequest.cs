namespace API.Models.Request.RentalPoint
{
    public class CreateRentalPointRequest
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public float? LocationX { get; set; }
        public float? LocationY { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}