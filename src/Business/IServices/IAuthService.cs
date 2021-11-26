﻿using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IAuthService
    {
        Task<LoginSuccessModel> LoginAsync(LoginRegisterModel loginModel);
        Task RegisterUserAsync(LoginRegisterModel loginRequest);
        Task<RefreshTokenSuccessModel> RefreshTokenAsync(string refreshTokenRequest);
    }
}