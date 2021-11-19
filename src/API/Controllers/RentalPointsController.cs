using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Response.RentalPoint;
using AutoMapper;
using Business.IServices;
using Business.Models;
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
        public async Task<IActionResult> GetAllAsync()
        {
            var rpResponseModels = await _rentalPointService.GetAllAsync();
            return Ok(_mapper.Map<List<RentalPointModel>, List<RentalPointResponseModel>>(rpResponseModels));
        }
    }
}