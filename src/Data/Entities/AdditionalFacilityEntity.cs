﻿using System;

namespace Data.Entities
{
    public class AdditionalFacilityEntity : Entity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Guid RentalPointId { get; set; }
        public RentalPointEntity RentalPoint { get; set; }
    }
}