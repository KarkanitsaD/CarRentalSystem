namespace Business.Query
{
    public class CarQueryModel : QueryModel
    {
        public string CarBrand { get; set; }
        public decimal? MaxFuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int? NumberOfSeats { get; set; }
        public decimal MinPricePerDay { get; set; }
        public decimal MaxPricePerDay { get; set; }
    }
}