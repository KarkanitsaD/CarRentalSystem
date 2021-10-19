namespace Business.FilterModels
{
    public class CarFilterModel : FilterModel
    {
        public string CarBrand { get; set; }
        public decimal? FuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int? NumberOfSeats { get; set; }
        public string Color { get; set; }
        public decimal MinPricePerDay { get; set; }
        public decimal MaxPricePerDay { get; set; }
    }
}
