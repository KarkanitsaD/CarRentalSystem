using System.Collections.Generic;
using Business.Models.Country;

namespace Business.IServices
{
    public interface ICountryService
    {
        IEnumerable<CountryModel> GetList();
    }
}