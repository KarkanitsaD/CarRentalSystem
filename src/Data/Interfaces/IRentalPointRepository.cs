using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IRentalPointRepository : IRepository<RentalPointEntity, int>
    {
        Task<IList<string>> GetRentalPointsCountriesAsync();
        Task<IList<string>> GetRentalPointsCitiesAsync();
        Task<IList<string>> GetRentalPointTitlesAsync();
    }
}
