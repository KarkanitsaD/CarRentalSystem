using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Request.Booking;
using API.Models.Response.Booking;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Query.Booking;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync([FromHeader] string authorization, [FromQuery] BookingQueryModel queryModel)
        {
            var (bookingsModels, itemsTotalCount) = await _bookingService.GetAllAsync(authorization, queryModel);
            var bookings = _mapper.Map<List<BookingModel>, List<BookingResponse>>(bookingsModels);
            return Ok(new { bookings, itemsTotalCount });
        }
    }
}