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
        public async Task<FileContentResult> GetAsync(Guid carId)
        {
            var picture = await _carPictureService.GetAsync(carId);
            return new FileContentResult(picture.Content, picture.Extension){FileDownloadName = picture.ShortName};
        }
    }
}