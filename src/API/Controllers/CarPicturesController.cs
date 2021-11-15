using System;
using System.Threading.Tasks;
using Business.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPicturesController : ControllerBase
    {
        private readonly ICarPictureService _carPictureService;

        public CarPicturesController(ICarPictureService carPictureService)
        {
            _carPictureService = carPictureService;
        }

        [HttpGet]
        [Route("{carId}")]
        public async Task<IActionResult> GetAsync(Guid carId)
        {
            return Ok(await _carPictureService.GetAsync(carId));
        }
    }
}