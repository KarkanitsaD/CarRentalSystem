﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IBookingService
    {
        Task<BookingModel> GetAsync(Guid id);
        IEnumerable<BookingModel> GetList();
        Task CreateAsync(BookingModel bookingModel);
        Task UpdateAsync(Guid id, BookingModel bookingModel);
        Task DeleteAsync(Guid id);
    }
}