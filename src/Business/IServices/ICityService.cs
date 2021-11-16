using System.Collections.Generic;
using Business.Models;

namespace Business.IServices
{
    public interface ICityService
    {
        IEnumerable<CityModel> GetList();
    }
}