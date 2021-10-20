using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;
using Data;
using Data.Entities;
using Data.Query;
using Data.Repositories;

namespace Business.Services
{
    public class RentalPointService : IRentalPointService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly RentalPointRepository _rentalPointRepository;

        public RentalPointService(IMapper mapper, ApplicationContext context, RentalPointRepository rentalPointRepository)
        {
            _mapper = mapper;
            _context = context;
            _rentalPointRepository = rentalPointRepository;
        }

        public async Task<RentalPointModel> GetAsync(int id)
        {
            var filterRule = new FilterRule<RentalPointEntity, int>
            {
                FilterExpression = rentalPoint =>
                    rentalPoint.Id == id
            };

            var entity = await _rentalPointRepository.GetAsync(filterRule);

            return _mapper.Map<RentalPointEntity, RentalPointModel>(entity);
        }

        public async Task<IList<RentalPointModel>> GetListAsync(RentalPointFilterModel rentalPointFilterModel)
        {
            var filterRule = DefineFilterRule(rentalPointFilterModel);
            var sortRule = DefineSortRule(rentalPointFilterModel);
            var queryParameters = new QueryParameters<RentalPointEntity, int>()
            {
                FilterRule = filterRule,
                SortRule = sortRule
            };

            var entities = await _rentalPointRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<RentalPointEntity>, IList<RentalPointModel>>(entities);
        }

        public async Task<IList<RentalPointModel>> GetPageListAsync(RentalPointFilterModel rentalPointFilterModel)
        {
            var filterRule = DefineFilterRule(rentalPointFilterModel);
            var sortRule = DefineSortRule(rentalPointFilterModel);
            var queryParameters = new QueryParameters<RentalPointEntity, int>()
            {
                FilterRule = filterRule,
                SortRule = sortRule,
                PaginationRule = new PaginationRule()
                {
                    Index = rentalPointFilterModel.PageIndex,
                    Size = rentalPointFilterModel.PageSize
                }
            };

            var entities = await _rentalPointRepository.GetPageListAsync(queryParameters);

            return _mapper.Map<IList<RentalPointEntity>, IList<RentalPointModel>>(entities);
        }

        public async Task CreateAsync(RentalPointModel rentalPointModel)
        {
            var entity = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);

            await _rentalPointRepository.CreateAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RentalPointModel rentalPointModel)
        {
            var entity = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);

            _rentalPointRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _rentalPointRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");

            await _context.SaveChangesAsync();
        }

        public async Task<IList<string>> GetAllCountries()
        {
            var countries = await _rentalPointRepository.GetRentalPointsCountriesAsync();

            return countries;
        }

        public async Task<IList<string>> GetAllCities()
        {
            var cities = await _rentalPointRepository.GetRentalPointsCitiesAsync();

            return cities;
        }

        public async Task<IList<string>> GetTitles()
        {
            var titles = await _rentalPointRepository.GetRentalPointTitlesAsync();

            return titles;
        }

        private FilterRule<RentalPointEntity, int> DefineFilterRule(RentalPointFilterModel rentalPointFilterModel)
        {
            throw new NotImplementedException();
            //TODO: write logic to filter rental points
        }

        private SortRule<RentalPointEntity, int> DefineSortRule(RentalPointFilterModel rentalPointFilterModel)
        {
            var sortRule = new SortRule<RentalPointEntity, int>();

            if (rentalPointFilterModel.InAscendingOrder != null)
            {
                sortRule.InAscendingOrder = (bool)rentalPointFilterModel.InAscendingOrder;
                sortRule.SortExpression = rentalPoint => rentalPoint.Cars.Count;
            }

            return sortRule;
        }
    }
}
