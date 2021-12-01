using System;

namespace API.Models.Request.RentalPoint
{
    public class UpdateRentalPointRequest : RentalPointRequest
    {
        public Guid Id { get; set; }
    }
}