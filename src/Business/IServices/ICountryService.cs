using System.Collections.Generic;
using Business.Models;

namespace Business.IServices
{
    public interface ICountryService
    {
        IEnumerable<CountryModel> GetList();
    }
}