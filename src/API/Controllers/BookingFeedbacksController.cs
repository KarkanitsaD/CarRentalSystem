using System;
using System.Collections.Generic;
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
        [Route("booking/{bookingId:guid}")]
        public async Task<IActionResult> GetByBookingIdAsync([FromRoute] Guid bookingId)
        {
            var model = await _bookingFeedbackService.GetAsync(bookingId);
            var response = _mapper.Map<BookingFeedbackModel, BookingFeedbackResponse>(model);
            return Ok(response);
        }

        [HttpGet]
        [Route("car/{carId:guid}")]
        public async Task<IActionResult> GetByCarId([FromRoute] Guid carId)
        {
            var models = await _bookingFeedbackService.GetAllByCarIdAsync(carId);
            var response = _mapper.Map<List<BookingFeedbackModel>, List<BookingFeedbackResponse>>(models);
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