using Microsoft.AspNetCore.Identity;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Models.DTO.Auth.Response;
using System.Security.Claims;

namespace NZWalks.API.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<LoginResponseViewModel> Login(LoginRequest loginRequest);
        Task<LoginResponseViewModel> Register(RegisterRequest registerRequest);
        Task<UserExistsResponseViewModel> UserExists(string userName);
    }
}
