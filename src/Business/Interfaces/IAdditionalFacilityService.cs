﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IAdditionalFacilityService
    {
        IEnumerable<AdditionalFacilityModel> GetList();
        Task CreateAsync(AdditionalFacilityModel additionalFacilityModel);
        Task UpdateAsync(AdditionalFacilityModel additionalFacilityModel);
        Task DeleteAsync(int id);
    }
}