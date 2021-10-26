using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel requestModel);
        Task<AuthenticateResponseModel> RegisterUser(UserRegistrationModel registrationModel);
        Task RevokeToken(RefreshTokenRequestModel refreshToken);
    }
}