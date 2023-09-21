using Microsoft.AspNetCore.Identity;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Models.DTO.Auth.Response;
using NZWalks.API.Repositories.Shared;

namespace NZWalks.API.Repositories.Auth
{
    public interface IAuthRepository : IGenericRepository<IdentityUser>
    {
        Task<LoginResponseViewModel> Login(LoginRequest loginRequest);
        Task<LoginResponseViewModel> Register(RegisterRequest registerRequest);
        Task<UserExistsResponseViewModel> UserExists(string userName);
    }
}
