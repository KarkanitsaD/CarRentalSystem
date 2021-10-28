using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.IServices;
using Business.Models.Authenticate;
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
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthService(ITokenService tokenService, IUserRepository userRepository, IRoleRepository roleRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.GetByAsync(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                throw new NotAuthorizedException("User with this credentials not found.");
            }

            string token = _tokenService.GenerateToken(user);

            var refreshToken = _tokenService.GenerateRefreshToken(user.Id);
            user.RefreshToken = refreshToken;
            await _userRepository.UpdateAsync(user);

            return new LoginResponseModel(user, token, refreshToken.Token);
        }

        public async Task RegisterUserAsync(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.GetByAsync(loginRequest.Email);

            if (user != null)
            {
                throw new NotAuthenticatedException("User with that credentials already exists.");
            }

            var userRoles = _roleRepository.GetList().Where(role => role.Title == Policy.ForUserOnly);

            user = new UserEntity
            {
                Email = loginRequest.Email,
                PasswordHash = loginRequest.Password,
                Roles = new List<RoleEntity>(userRoles)
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task<RefreshTokenResponseModel> RefreshTokenAsync(RefreshTokenRequestModel refreshTokenRequest)
        {
            var refreshToken = await _refreshTokenRepository.GetByAsync(refreshTokenRequest.RefreshToken);

            if (refreshToken == null)
            {
                throw new BadRequestException("Invalid refresh token.");
            }

            if (!refreshToken.IsActive)
            {
                throw new BadRequestException("Refresh token is not active.");
            }

            var user = refreshToken.User;

            string token = _tokenService.GenerateToken(user);

            refreshToken = _tokenService.GenerateRefreshToken(user.Id);
            user.RefreshToken = refreshToken;
            await _userRepository.UpdateAsync(user);

            return new RefreshTokenResponseModel(token, refreshToken.Token);
        }

        public async Task RevokeTokenAsync(RevokeTokenRequestModel revokeTokenRequest)
        {
            var refreshToken = await _refreshTokenRepository.GetByAsync(revokeTokenRequest.RefreshToken);

            if (refreshToken == null)
            {
                throw new BadRequestException("Invalid refresh token.");
            }

            if (!refreshToken.IsActive)
            {
                throw new BadRequestException("Refresh token is not active.");
            }

            refreshToken.IsRevoked = true;
            await _refreshTokenRepository.UpdateAsync(refreshToken);
        }
    }
}