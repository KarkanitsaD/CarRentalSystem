﻿using System;

namespace API.Models.Response.AdditionalFacility
{
    public class CreateAdditionalFacilityResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Guid RentalPointId { get; set; }
    }
}