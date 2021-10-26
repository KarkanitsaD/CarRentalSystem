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
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel requestModel)
        {
            var user = await _userRepository.GetByEmailAndPassword(requestModel.Email, requestModel.Password);

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
    }
}