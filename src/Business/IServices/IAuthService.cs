using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IAuthService
    {
        Task<LoginSuccessModel> LoginAsync(LoginModel loginModel);
        Task RegisterUserAsync(LoginModel loginRequest);
        Task<RefreshTokenSuccessModel> RefreshTokenAsync(string refreshTokenRequest);
    }
}