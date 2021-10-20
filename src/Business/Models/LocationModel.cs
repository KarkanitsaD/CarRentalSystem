namespace Business.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? RentalPointId { get; set; }
    }
}
