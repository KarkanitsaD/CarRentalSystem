using System.Threading.Tasks;
using Data.Entities;
using Data.Query;
using Data.Query.FiltrationModels;

namespace Data.IRepositories
{
    public interface IRentalPointRepository : IBaseRepository<RentalPointEntity>
    {
        Task<PageResult<RentalPointEntity>> GetPageListAsync(RentalPointFiltrationModel rentalPointFiltrationModel,
            int pageIndex, int pageSize);
    }
}