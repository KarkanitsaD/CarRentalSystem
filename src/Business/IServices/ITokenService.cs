using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface ITokenService
    {
        Task<string> GenerateToken(AuthenticateRequestModel requestModel);
        bool ValidateToken(string token);
    }
}