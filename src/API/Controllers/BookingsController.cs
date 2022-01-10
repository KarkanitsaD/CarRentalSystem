﻿using System;
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
using Business.Query.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = Policy.ForUserOnly)]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingsController(IBookingService bookingService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookingRequest bookingRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim =>
                claim.Type == ClaimTypes.NameIdentifier)?.Value;

            var booking = _mapper.Map<CreateBookingRequest, BookingModel>(bookingRequest);

            await _bookingService.CreateAsync(Guid.Parse(userId), booking);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] BookingQueryModel queryModel)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim =>
                    claim.Type == ClaimTypes.NameIdentifier)?.Value;

            var (bookingsModels, itemsTotalCount) = await _bookingService.GetAllAsync(Guid.Parse(userId), queryModel);
            var bookings = _mapper.Map<List<BookingModel>, List<BookingResponse>>(bookingsModels);
            return Ok(new { bookings, itemsTotalCount });
        }

        [HttpDelete]
        [Route("{bookingId:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid bookingId)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim =>
                claim.Type == ClaimTypes.NameIdentifier)?.Value;

            await _bookingService.DeleteAsync(Guid.Parse(userId), bookingId);
            return Ok();
        }
    }
}