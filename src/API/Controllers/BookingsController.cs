﻿using System;
using System.Collections.Generic;
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
        private readonly ITokenService _tokenService;
        public BookingsController(IBookingService bookingService, IMapper mapper, ITokenService tokenService)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Authorize(Policy = Policy.ForUserOnly)]
        public async Task<IActionResult> CreateAsync([FromHeader] string authorization, [FromBody] CreateBookingRequest bookingRequest)
        {
            var userId = _tokenService.GetClaimFromJwt(authorization.Split(' ')[1], ClaimTypes.NameIdentifier).Value;

            var booking = _mapper.Map<CreateBookingRequest, BookingModel>(bookingRequest);

            await _bookingService.CreateAsync(Guid.Parse(userId), booking);

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

        [HttpDelete]
        [Authorize(Policy = Policy.ForUserOnly)]
        [Route("{bookingId:guid}")]
        public async Task<IActionResult> DeleteAsync([FromHeader] string authorization, [FromRoute] Guid bookingId)
        {
            await _bookingService.DeleteAsync(authorization, bookingId);
            return Ok();
        }
    }
}