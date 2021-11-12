using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface ICarPictureService
    {
        IEnumerable<CarPictureModel> GetList();
        Task<CarPictureModel> GetAsync(Guid carId);
    }
}