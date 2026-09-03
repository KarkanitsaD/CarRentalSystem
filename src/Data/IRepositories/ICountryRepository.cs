using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface ICountryRepository : IBaseRepository<CountryEntity>
    {
        Task<CountryEntity> GetByTitleAsync(string title);
    }
}