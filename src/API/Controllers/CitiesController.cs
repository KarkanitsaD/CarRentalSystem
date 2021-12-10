using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Request.City;
using API.Models.Response.City;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = Policy.ForAdminOnly)]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetListAsync()
        {
            var cities = await _cityService.GetListAsync();
            return Ok(_mapper.Map<List<CityModel>, List<CityResponseModel>>(cities));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCityRequest request)
        {
            var model = await _cityService.CreateAsync(_mapper.Map<CreateCityRequest, CityModel>(request));
            return Ok(_mapper.Map<CityModel, CityResponseModel>(model));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _cityService.DeleteAsync(id);
            return Ok();
        }
    }
}