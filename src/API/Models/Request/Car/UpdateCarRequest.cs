using System;

namespace API.Models.Request.Car
{
    public class UpdateCarRequest : CarRequest
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
    }
}