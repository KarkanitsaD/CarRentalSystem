using System;
using System.Threading.Tasks;
using API.Models.Request.AdditionalFacility;
using API.Models.Response.AdditionalFacility;
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
    public class AdditionalFacilitiesController : ControllerBase
    {
        private readonly IAdditionalFacilityService _additionalFacilityService;
        private readonly IMapper _mapper;

        public AdditionalFacilitiesController(IAdditionalFacilityService additionalFacilityService, IMapper mapper)
        {
            _additionalFacilityService = additionalFacilityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAdditionalFacilityRequest createRequest)
        {
            var model = _mapper.Map<CreateAdditionalFacilityRequest, AdditionalFacilityModel>(createRequest);
            model = await _additionalFacilityService.CreateAsync(model);
            var response = _mapper.Map<AdditionalFacilityModel, CreateAdditionalFacilityResponse>(model);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _additionalFacilityService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateAdditionalFacilityRequest updateRequest)
        {
            var updateModel = _mapper.Map<UpdateAdditionalFacilityRequest, AdditionalFacilityModel>(updateRequest);
            await _additionalFacilityService.UpdateAsync(id, updateModel);
            return Ok();
        }
    }
}