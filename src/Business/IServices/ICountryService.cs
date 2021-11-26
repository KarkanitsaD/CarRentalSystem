using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface ICountryService
    {
        Task<List<CountryModel>> GetListAsync();
        Task<CountryModel> CreateAsync(string title);
        Task DeleteAsync(Guid id);
    }
}