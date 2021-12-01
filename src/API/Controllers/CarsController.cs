using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Request.Car;
using API.Models.Response.Car;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Business.Query.Car;
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
        [Authorize]
        public async Task<IActionResult> GetCarsAsync([FromQuery] CarQueryModel queryModel)
        {
            var (carsModels, itemsTotalCount) = await _carService.GetPageListAsync(queryModel);
            var cars = _mapper.Map<List<CarModel>, List<CarResponseModel>>(carsModels);
            return Ok(new { cars, itemsTotalCount });
            
        }

        [HttpPut]
        [Route("{carId:guid}/lock")]
        [Authorize]
        public async Task<IActionResult> LockCarAsync([FromRoute] Guid carId)
        {
            await _carService.LockCarAsync(carId);
            return Ok();
        }



        [HttpPost]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> AddCar([FromBody] CreateCarRequest addCarModel)
        {
            var car = _mapper.Map<CreateCarRequest, CarModel>(addCarModel);
            await _carService.CreateAsync(car);
            return Ok();
        }

        [HttpPut]
        [Route("{carId:guid}")]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid carId, [FromBody] UpdateCarRequest updateCarModel)
        {
            var car = _mapper.Map<UpdateCarRequest, CarModel>(updateCarModel);
            await _carService.UpdateAsync(carId, car);
            return Ok();
        }

        [HttpDelete]
        [Route("{carId:guid}")]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid carId)
        {
            await _carService.DeleteAsync(carId);
            return Ok();
        }
    }
}