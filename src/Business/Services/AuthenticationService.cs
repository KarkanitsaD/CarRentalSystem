using System.Threading.Tasks;
using Business.Exceptions;
using Business.Helpers;
using Business.IServices;
using Business.Models;
using Data.IRepositories;

namespace Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtTokenHandler _tokenHandler;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(JwtTokenHandler tokenHandler, IUserRepository userRepository)
        {
            _tokenHandler = tokenHandler;
            _userRepository = userRepository;
        }

        public async Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel requestModel)
        {
            var user = await _userRepository.GetByEmailAndPassword(requestModel.Email, requestModel.Password);

            if (user == null)
                throw new NotAuthenticatedException("User with this credentials not found.");

            var token = _tokenHandler.GenerateToken(user);

            return new AuthenticateResponseModel(user, token);
        }
    }
}
