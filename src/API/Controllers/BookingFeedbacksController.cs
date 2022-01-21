using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Models.Request.Booking;
using API.Models.Response.Booking;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingFeedbacksController : ControllerBase
    {
        private readonly IBookingFeedbackService _bookingFeedbackService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingFeedbacksController(IBookingFeedbackService bookingFeedbackService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _bookingFeedbackService = bookingFeedbackService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateBookingFeedbackRequest updateRequest)
        {
            var model = _mapper.Map<UpdateBookingFeedbackRequest, BookingFeedbackModel>(updateRequest);
            var isAdmin = _httpContextAccessor.HttpContext.User.IsInRole(Policy.ForAdminOnly);
            if (isAdmin)
            {
                await _bookingFeedbackService.UpdateByAdminAsync(id, model);
            }
            else
            {
                var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim =>
                    claim.Type == ClaimTypes.NameIdentifier)?.Value;
                await _bookingFeedbackService.UpdateByUserAsync(id, model, Guid.Parse(userId));
            }

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