﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Helpers;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Data.Entities;
using Data.IRepositories;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly PasswordHasher _passwordHasher;

        public AuthService(ITokenService tokenService, IUserRepository userRepository, IRoleRepository roleRepository, PasswordHasher passwordHasher)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginSuccessModel> LoginAsync(LoginRegisterModel loginRequest)
        {
            var user = await _userRepository.GetByCredentialsAsync(loginRequest.Email, _passwordHasher.GeneratePasswordHash(loginRequest.Password));

            if (user == null)
            {
                throw new NotAuthorizedException("User with this credentials not found.");
            }

            var userClaims = GetUserClaims(user);
            var jwt = _tokenService.GenerateJwt(userClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            if (user.RefreshToken == null)
            {
                await _tokenService.CreateRefreshTokenAsync(user.Id, refreshToken);
            }
            else
            {
                await _tokenService.UpdateRefreshTokenAsync(user.Id, refreshToken);
            }

            return new LoginSuccessModel(user, jwt, refreshToken);
        }

        public async Task RegisterUserAsync(LoginRegisterModel loginRequest)
        {
            var user = await _userRepository.GetByEmailAsync(loginRequest.Email);

            if (user != null)
            {
                throw new NotAuthenticatedException("User with that credentials already exists.");
            }
            var roles = await _roleRepository.GetListAsync();
            var userRole = roles.First(role => role.Title == Policy.ForUserOnly);

            user = new UserEntity
            {
                Email = loginRequest.Email,
                PasswordHash = _passwordHasher.GeneratePasswordHash(loginRequest.Password),
                RoleId= userRole.Id
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task<RefreshTokenSuccessModel> RefreshTokenAsync(string refreshTokenRequest)
        {
            await _tokenService.ValidateRefreshTokenAsync(refreshTokenRequest);

            var user = await _userRepository.GetByRefreshTokenAsync(refreshTokenRequest);
            var userClaims = GetUserClaims(user);

            var jwt = _tokenService.GenerateJwt(userClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _tokenService.UpdateRefreshTokenAsync(user.Id, refreshToken);

            return new RefreshTokenSuccessModel(jwt, refreshToken);
        }

        private IEnumerable<Claim> GetUserClaims(UserEntity user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Title)
            };

            return claims;
        }
    }
}