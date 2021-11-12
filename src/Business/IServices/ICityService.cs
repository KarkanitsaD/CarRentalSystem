using System.Collections.Generic;
using Business.Models.City;

namespace Business.IServices
{
    public interface ICityService
    {
        IEnumerable<CityModel> GetList();
    }
}