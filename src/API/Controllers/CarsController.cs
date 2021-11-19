using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Request.Car;
using API.Models.Response.Car;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{carId:guid}")]
        public async Task<IActionResult> GetCar([FromRoute] Guid carId)
        {
            var car = await _carService.GetAsync(carId);
            return Ok(car);
        }


        [HttpGet]
        public async Task<IActionResult> GetCarsAsync([FromQuery] CarQueryModel queryModel)
        {
            var (carsModels, itemsTotalCount) = await _carService.GetPageListAsync(queryModel);
            var cars = _mapper.Map<List<CarModel>, List<CarResponseModel>>(carsModels);
            return Ok(new { cars, itemsTotalCount });
            
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] AddCarRequestModel addCarModel)
        {
            var car = _mapper.Map<AddCarRequestModel, CarModel>(addCarModel);
            await _carService.CreateAsync(car);
            return Ok();
        }

        [HttpPut]
        [Route("{carId:guid}")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid carId, [FromBody] UpdateCarRequestModel updateCarModel)
        {
            var car = _mapper.Map<UpdateCarRequestModel, CarModel>(updateCarModel);
            await _carService.UpdateAsync(carId, car);
            return Ok();
        }

        [HttpDelete]
        [Route("{carId:guid}")]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid carId)
        {
            await _carService.DeleteAsync(carId);
            return Ok();
        }
    }
}