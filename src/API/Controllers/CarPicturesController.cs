using System;
using System.Threading.Tasks;
using API.Models.Response.CarPicture;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPicturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarPictureService _carPictureService;

        public CarPicturesController(ICarPictureService carPictureService, IMapper mapper)
        {
            _carPictureService = carPictureService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{carId}")]
        [ResponseCache(CacheProfileName = CacheOptions.CacheOptions.BaseCacheProfile)]
        public async Task<IActionResult> GetAsync(Guid carId)
        {
            var picture = await _carPictureService.GetAsync(carId);
            return Ok(_mapper.Map<CarPictureModel, CarPictureResponseModel>(picture));
        }
    }
}