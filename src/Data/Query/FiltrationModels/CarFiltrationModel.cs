﻿using System;

namespace Data.Query.FiltrationModels
{
    public class CarFiltrationModel
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public decimal? MinPricePerDay { get; set; }
        public decimal? MaxPricePerDay { get; set; }
        public Guid? RentalPointId { get; set; }
        public DateTime? KeyReceivingTime { get; set; }
        public DateTime? KeyHandOverTime { get; set; }
    }
}