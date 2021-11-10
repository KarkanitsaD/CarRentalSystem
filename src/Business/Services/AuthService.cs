using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.Helpers;
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
        private readonly PasswordHasher _passwordHasher;

        public AuthService(ITokenService tokenService, IUserRepository userRepository, IRoleRepository roleRepository, PasswordHasher passwordHasher)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequest)
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

            return new LoginResponseModel(user, jwt, refreshToken);
        }

        public async Task RegisterUserAsync(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.GetByEmailAsync(loginRequest.Email);

            if (user != null)
            {
                throw new NotAuthenticatedException("User with that credentials already exists.");
            }

            var userRoles = _roleRepository.GetList().Where(role => role.Title == Policy.ForUserOnly);

            user = new UserEntity
            {
                Email = loginRequest.Email,
                PasswordHash = _passwordHasher.GeneratePasswordHash(loginRequest.Password),
                Roles = new List<RoleEntity>(userRoles)
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task<RefreshTokenResponseModel> RefreshTokenAsync(string refreshTokenRequest)
        {
            await _tokenService.ValidateRefreshTokenAsync(refreshTokenRequest);

            var user = await _userRepository.GetByRefreshTokenAsync(refreshTokenRequest);
            var userClaims = GetUserClaims(user);

            var jwt = _tokenService.GenerateJwt(userClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _tokenService.UpdateRefreshTokenAsync(user.Id, refreshToken);

            return new RefreshTokenResponseModel(jwt, refreshToken);
        }

        private IEnumerable<Claim> GetUserClaims(UserEntity user)
        {
            var roleClaims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Title));
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            claims.AddRange(roleClaims);

            return claims;
        }
    }
}