using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface ICarPictureService
    {
        Task<CarPictureModel> GetAsync(Guid carId);
    }
}