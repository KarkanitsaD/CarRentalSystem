﻿using System.Threading.Tasks;
using Business.IServices;
using Business.Models.Authenticate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel loginRequest)
        {
            return Ok(await _authService.LoginAsync(loginRequest));
        }

        [Route("register")]
        public async Task<IActionResult> RegisterAsync(LoginRequestModel loginRequest)
        {
            await _authService.RegisterUserAsync(loginRequest);

            return Ok();
        }

        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestModel refreshRequestModel)
        {
            return Ok(await _authService.RefreshTokenAsync(refreshRequestModel));
        }

        [Route("revoke-token")]
        public async Task<IActionResult> RevokeToken(RevokeTokenRequestModel revokeTokenRequest)
        {
            await _authService.RevokeTokenAsync(revokeTokenRequest);
            return Ok();
        }

        [Authorize(Policy = "Vova")]
        [Route("test")]
        public string TetsAsync()
        {
            return "test";
        }
    }
}