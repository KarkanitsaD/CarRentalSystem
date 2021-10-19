﻿using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class CarEntity : Entity<Guid>
    {
        public string CarBrand { get; set; }
        public decimal FuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public string VehicleNumber { get; set; }
        public int? RentalPointId { get; set; }
        public virtual RentalPointEntity RentalPoint { get; set; }
        public bool IsBooked { get; set; }
        public DateTime LastViewTime { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
