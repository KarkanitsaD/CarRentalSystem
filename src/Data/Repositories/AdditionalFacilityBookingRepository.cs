using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class AdditionalFacilityBookingRepository : BaseRepository<AdditionalFacilityBookingEntity>, IAdditionalFacilityBookingRepository
    {
        public AdditionalFacilityBookingRepository(CarRentalSystemContext carRentalSystemContext)
            : base(carRentalSystemContext)
        {
        }
    }
}