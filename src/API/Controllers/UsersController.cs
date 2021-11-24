using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Request.User;
using API.Models.Response.User;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<List<UserModel>, List<UserResponse>>(users));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserRequest updateModel)
        {
            var user = _mapper.Map<UpdateUserRequest, UserModel>(updateModel);
            await _userService.UpdateAsync(id, user);
            return Ok();
        }
    }
}