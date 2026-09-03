using System;

namespace API.Models.Request.RentalPoint
{
    public class UpdateRentalPointRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}