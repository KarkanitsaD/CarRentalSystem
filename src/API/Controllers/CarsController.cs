using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models.Request.Car;
using API.Models.Response.Car;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Business.Query.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarsController(ICarService carService, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _carService = carService;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("{carId:guid}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCar([FromRoute] Guid carId)
        {
            var car = await _carService.GetAsync(carId);
            return Ok(car);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCarsAsync([FromQuery] CarQueryModel queryModel)
        {
            var idClaim = _httpContextAccessor.HttpContext.User
                .Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
            Guid? userId = idClaim == null ? (Guid?) null : Guid.Parse(idClaim.Value);
            var (carsModels, itemsTotalCount) = await _carService.GetPageListAsync(queryModel, userId);
            var cars = _mapper.Map<List<CarModel>, List<CarResponseModel>>(carsModels);
            return Ok(new { cars, itemsTotalCount });
        }

        [HttpPut]
        [Route("{carId:guid}/lock")]
        [Authorize(Policy = Policy.ForUserOnly)]
        public async Task<IActionResult> LockCarAsync([FromHeader] string authorization, [FromRoute] Guid carId)
        {
            var userIdClaim = _tokenService.GetClaimFromJwt(authorization.Split(' ')[1], ClaimTypes.NameIdentifier).Value;
            await _carService.LockCarAsync(carId, Guid.Parse(userIdClaim));
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateCarRequest addCarModel)
        {
            var car = _mapper.Map<CreateCarRequest, CarModel>(addCarModel);
            await _carService.CreateAsync(car);
            return Ok();
        }

        [HttpPut]
        [Route("{carId:guid}")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid carId, [FromBody] UpdateCarRequest updateCarModel)
        {
            var car = _mapper.Map<UpdateCarRequest, CarModel>(updateCarModel);
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