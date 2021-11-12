using Business.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalPointsController : ControllerBase
    {
        private readonly IRentalPointService _rentalPointService;

        public RentalPointsController(IRentalPointService rentalPointService)
        {
            _rentalPointService = rentalPointService;
        }

        [HttpGet]
        [Route("titles")]
        public IActionResult GetRentalPointsTitles()
        {
            return Ok(_rentalPointService.GetRentalPointAddCarModels());
        }
    }
}