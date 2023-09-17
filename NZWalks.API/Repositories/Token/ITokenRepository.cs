using Microsoft.AspNetCore.Identity;
using NZWalks.API.Models.DTO.Auth.Response;
using System.Security.Claims;

namespace NZWalks.API.Repositories.Token
{
    public interface ITokenRepository
    {
        Task<JwtAuthResponseViewModel> GenerateToken(IdentityUser user, IEnumerable<Claim> claims);
    }
}
