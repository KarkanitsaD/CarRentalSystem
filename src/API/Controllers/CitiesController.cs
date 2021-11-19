using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Response.City;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetListAsync()
        {
            var cities = await _cityService.GetListAsync();
            return Ok(_mapper.Map<List<CityModel>, List<CityResponseModel>>(cities));
        }
    }
}