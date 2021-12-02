using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Request.RentalPoint;
using API.Models.Response.RentalPoint;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Query.RentalPoint;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalPointsController : ControllerBase
    {
        private readonly IRentalPointService _rentalPointService;
        private readonly IMapper _mapper;

        public RentalPointsController(IRentalPointService rentalPointService, IMapper mapper)
        {
            _rentalPointService = rentalPointService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var rentalPoint = await _rentalPointService.GetAsync(id);
            return Ok(_mapper.Map<RentalPointModel, RentalPointResponseModel>(rentalPoint));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] RentalPointQueryModel queryModel)
        {
            var (rentalPointsModels, itemsTotalCount) = await _rentalPointService.GetPageListAsync(queryModel);
            var rentalPoints = _mapper.Map<List<RentalPointModel>, List<RentalPointResponseModel>>(rentalPointsModels);
            return Ok(new { rentalPoints, itemsTotalCount });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRentalPointRequest request)
        {
            var model = _mapper.Map<CreateRentalPointRequest, RentalPointModel>(request);

            await _rentalPointService.CreateAsync(model);
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id,
            [FromBody] UpdateRentalPointRequest updateModel)
        {
            var rentalPoint = _mapper.Map<UpdateRentalPointRequest, RentalPointModel>(updateModel);

            await _rentalPointService.UpdateAsync(id, rentalPoint);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _rentalPointService.DeleteAsync(id);
            return Ok();
        }
    }
}