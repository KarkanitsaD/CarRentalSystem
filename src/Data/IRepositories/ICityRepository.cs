using System;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface ICityRepository : IBaseRepository<CityEntity>
    {
        Task<CityEntity> GetByTitleAndCountryIdAsync(string title, Guid countryId);
    }
}