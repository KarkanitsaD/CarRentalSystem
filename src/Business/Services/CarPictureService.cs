using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.IRepositories;

namespace Business.Services
{
    public class CarPictureService : ICarPictureService
    {
        private readonly IMapper _mapper;
        private readonly ICarPictureRepository _carPictureRepository;

        public CarPictureService(ICarPictureRepository carPictureRepository, IMapper mapper)
        {
            _carPictureRepository = carPictureRepository;
            _mapper = mapper;
        }

        public async Task<CarPictureModel> GetAsync(Guid carId)
        {
            var entity = await _carPictureRepository.GetByCarIdAsync(carId);
            return _mapper.Map<CarPictureEntity, CarPictureModel>(entity);
        }
    }
}