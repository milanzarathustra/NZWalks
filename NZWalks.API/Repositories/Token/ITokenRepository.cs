using Microsoft.AspNetCore.Identity;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Models.DTO.Auth.Response;
using System.Security.Claims;

namespace NZWalks.API.Repositories.Token
{
    public interface ITokenRepository
    {
        Task<JwtAuthResponseViewModel> GenerateTokens(IdentityUser user);
        Task<JwtAuthResponseViewModel?> RefreshTokens(RefreshRequest refreshRequest);
        Task<IEnumerable<Claim>> GetUserClaims(IdentityUser user);
    }
}
