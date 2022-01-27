﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface ICityService
    {
        Task<List<CityModel>> GetListAsync();
    }
}