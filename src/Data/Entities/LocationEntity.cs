namespace Data.Entities
{
    public class LocationEntity : Entity<int>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? RentalPointId { get; set; }
        public virtual RentalPointEntity RentalPoint { get; set; }
    }
}