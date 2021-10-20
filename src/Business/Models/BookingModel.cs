using System;
using System.Collections.Generic;
using Data.Entities;

namespace Business.Models
{
    public class BookingModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public int? RentalPointId { get; set; }
        public virtual RentalPointEntity RentalPoint { get; set; }
        public Guid CarId { get; set; }
        public virtual CarEntity Car { get; set; }
        public DateTime KeyReceivingTime { get; set; }
        public DateTime KeyHandOverTime { get; set; }
        public DateTime BookingTime { get; set; }

        public virtual ICollection<AdditionalFacilityEntity> AdditionalFacilities { get; set; }
    }
}
