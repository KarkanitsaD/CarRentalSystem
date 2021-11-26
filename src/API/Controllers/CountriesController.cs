using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Response.Country;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var countries = await _countryService.GetListAsync();
            return Ok(_mapper.Map<List<CountryModel>, List<CountryResponseModel>>(countries));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] string title)
        {
            var model = await _countryService.CreateAsync(title);
            return Ok(_mapper.Map<CountryModel, CountryResponseModel>(model));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _countryService.DeleteAsync(id);
            return Ok();
        }
    }
}