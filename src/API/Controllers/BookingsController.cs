using System.Threading.Tasks;
using API.Models.Request.Booking;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromHeader] string authorization, [FromBody] CreateBookingRequest bookingRequest)
        {
            var booking = _mapper.Map<CreateBookingRequest, BookingModel>(bookingRequest);

            await _bookingService.CreateAsync(authorization, booking);

            return Ok();
        }
    }
}