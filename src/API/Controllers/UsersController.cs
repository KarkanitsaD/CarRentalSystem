using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Request.User;
using API.Models.Response.User;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Business.Query;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAllAsync([FromQuery] UserQueryModel userQueryModel)
        {
            var (userModels, itemsTotalCount) = await _userService.GetPageListAsync(userQueryModel);
            var users = _mapper.Map<List<UserModel>, List<UserResponse>>(userModels);
            return Ok(new { users,  itemsTotalCount });
        }

        [HttpPost]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<CreateUserRequest, CreateUserModel>(createUserRequest);
            await _userService.CreateUser(user);
            return Ok();
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateUserRequest updateModel)
        {
            var user = _mapper.Map<UpdateUserRequest, UserModel>(updateModel);
            await _userService.UpdateAsync(id, user);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Policy = Policy.ForAdminOnly)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}