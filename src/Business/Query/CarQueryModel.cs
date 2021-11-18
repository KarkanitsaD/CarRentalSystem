namespace Business.Query
{
    public class CarQueryModel : QueryModel
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public decimal? MinPricePerDay { get; set; }
        public decimal? MaxPricePerDay { get; set; }
    }
}