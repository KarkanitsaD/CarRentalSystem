using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IRentalPointService
    {
        Task<List<RentalPointModel>> GetAllAsync();
    }
}