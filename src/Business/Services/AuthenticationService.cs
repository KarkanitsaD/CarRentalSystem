using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Contracts;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.IRepositories;
using Microsoft.Extensions.Options;

namespace Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenService _tokenService;
        private readonly JwtOptions _jwtOptions;


        public AuthenticationService(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IRoleRepository roleRepository, ITokenService tokenService, IOptions<JwtOptions> jwtOptions)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _roleRepository = roleRepository;
            _tokenService = tokenService;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel requestModel)
        {
            var user = await _userRepository.GetBy(requestModel.Email, requestModel.Password);

            if (user == null)
                throw new NotAuthorizedException("User with this credentials not found.");

            string token = _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            if (user.RefreshToken != null)
            {
                await _refreshTokenRepository.DeleteAsync(user.RefreshToken);
            }

            await _refreshTokenRepository.UpdateAsync(user.RefreshToken = refreshToken);

            return new AuthenticateResponseModel(user, token, refreshToken.Token);
        }

        public async Task<AuthenticateResponseModel> RegisterUser(UserRegistrationModel registrationModel)
        {
            var user = await _userRepository.GetBy(registrationModel.Email);

            if (user != null)
                throw new NotAuthenticatedException("User with this email already exists.");

            var userRole = _roleRepository.GetList().Where(role => role.Title == Policies.UserPolicy);

            user = new UserEntity
            {
                Email = registrationModel.Email,
                PasswordHash = registrationModel.Password,
                Name = registrationModel.Name,
                Roles = new List<RoleEntity>(userRole)
            };

            await _userRepository.CreateAsync(user);

            string token = _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            
            await _refreshTokenRepository.CreateAsync(user.RefreshToken = refreshToken);

            return new AuthenticateResponseModel(user, token, refreshToken.Token);
        }

        public async Task RevokeToken(RefreshTokenRequestModel refreshTokenModel)
        {
            var tokenEntity = await _refreshTokenRepository.Get(refreshTokenModel.Token);

            if (tokenEntity == null)
                throw new NotFoundException("There are no user with this token.");

            if (!tokenEntity.IsRevoked && (DateTime.Now - tokenEntity.CreationTime).Seconds > _jwtOptions.RefreshTokenLifeTimeInSeconds)
                throw new NotAuthenticatedException("This token is expired");

            tokenEntity.IsRevoked = true;
            await _refreshTokenRepository.UpdateAsync(tokenEntity);
        }
    }
}