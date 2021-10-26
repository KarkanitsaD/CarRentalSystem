using System.Threading.Tasks;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.IRepositories;

namespace Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel requestModel)
        {
            var user = await _userRepository.GetByEmailAndPassword(requestModel.Email, requestModel.Password);

            if (user == null)
                throw new NotAuthorizedException("User with this credentials not found.");

            string token = _tokenService.GenerateToken(user);

            return new AuthenticateResponseModel(user, token);
        }
    }
}