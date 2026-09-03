using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.Response.Role;
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
    [Authorize(Policy = Policy.ForAdminOnly)]
    public class RolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(_mapper.Map<List<RoleModel>, List<RoleResponse>>(roles));
        }
    }
}