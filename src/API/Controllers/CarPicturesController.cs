using System;
using System.Security.Claims;
using System.Threading.Tasks;
using API.ApplicationOptions;
using API.Models.Response.CarPicture;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarPicturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICarPictureService _carPictureService;
        private readonly ITokenService _tokenService;

        public CarPicturesController(ICarPictureService carPictureService, IMapper mapper, ITokenService tokenService)
        {
            _carPictureService = carPictureService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("{carId}")]
        [ResponseCache(CacheProfileName = CacheOptions.BaseCacheProfile)]
        public async Task<IActionResult> GetAsync(Guid carId, [FromHeader] string authorization)
        {
            SetCacheOptions(Response, authorization);
            var picture = await _carPictureService.GetAsync(carId);
            return Ok(_mapper.Map<CarPictureModel, CarPictureResponseModel>(picture));
        }

        private void SetCacheOptions(HttpResponse response, string authorization)
        {
            if (authorization != null)
            {
                var roleClaim = _tokenService.GetClaimFromJwt(authorization.Split(' ')[1], ClaimTypes.Role);
                if (roleClaim.Value == Policy.ForAdminOnly)
                {
                    response.Headers.Remove("cache-control");
                }
            }
        }
    }
}