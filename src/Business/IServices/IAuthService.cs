using System.Threading.Tasks;
using Business.Models.Authenticate;

namespace Business.IServices
{
    public interface IAuthService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequest);
        Task RegisterUserAsync(LoginRequestModel loginRequest);
        Task<RefreshTokenResponseModel> RefreshTokenAsync(string refreshTokenRequest);
    }
}