using System;
using System.Threading.Tasks;
using API.Models.Request.Booking;
using API.Models.Response.Booking;
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
    public class BookingFeedbacksController : ControllerBase
    {
        private readonly IBookingFeedbackService _bookingFeedbackService;
        private readonly IMapper _mapper;

        public BookingFeedbacksController(IBookingFeedbackService bookingFeedbackService, IMapper mapper)
        {
            _bookingFeedbackService = bookingFeedbackService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromBody] Guid bookingId)
        {
            var model = await _bookingFeedbackService.GetAsync(bookingId);
            var response = _mapper.Map<BookingFeedbackModel, BookingFeedbackResponse>(model);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = Policy.ForUserOnly)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookingFeedbackRequest request)
        {
            var modelToCreate = _mapper.Map<CreateBookingFeedbackRequest, BookingFeedbackModel>(request);
            await _bookingFeedbackService.CreateAsync(modelToCreate);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = Policy.ForAdminOnly)]
        [Route("{bookingFeedbackId:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid bookingFeedbackId)
        {
            await _bookingFeedbackService.DeleteAsync(bookingFeedbackId);
            return Ok();
        }
    }
}