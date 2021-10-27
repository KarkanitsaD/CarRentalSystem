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

        public AuthService(ITokenService tokenService, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.GetByAsync(loginRequest.Email, loginRequest.Password);

            if (user == null)
                throw new NotAuthorizedException("User with this credentials not found.");

            string token = _tokenService.GenerateToken(user);

            return new LoginResponseModel(user, token);
        }

        public async Task RegisterUserAsync(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.GetByAsync(loginRequest.Email, loginRequest.Password);

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
    }
}