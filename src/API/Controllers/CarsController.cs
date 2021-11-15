using System;
using System.Threading.Tasks;
using Business.IServices;
using Business.Models.Car;
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

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_carService.GetList());
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] AddCarModel addCarModel)
        {
            await _carService.CreateAsync(addCarModel);
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