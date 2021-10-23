using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IAuthorizationService
    {
        Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel requestModel);
    }
}
