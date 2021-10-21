﻿using Data.Entities;
using Data.Interfaces;
using Data.IRepositories;

namespace Data.Repositories
{
    public class AdditionalFacilityRepository : BaseRepository<AdditionalFacilityEntity, int>, IAdditionalFacilityRepository
    {
        public AdditionalFacilityRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}