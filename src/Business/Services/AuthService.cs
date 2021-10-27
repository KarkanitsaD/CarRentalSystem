using System.Threading.Tasks;
using Business.Exceptions;
using Business.IServices;
using Business.Models.Authenticate;
using Data.IRepositories;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public AuthService(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseModel>LoginAsync(LoginRequestModel loginRequest)
        {
            var user = await _userRepository.GetByAsync(loginRequest.Email, loginRequest.Password);

            if (user == null)
                throw new NotAuthorizedException("User with this credentials not found.");

            string token = _tokenService.GenerateToken(user);

            return new LoginResponseModel(user, token);
        }
    }
}