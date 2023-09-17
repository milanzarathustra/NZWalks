using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repositories.Auth
{
    public interface ITokenRepository
    {
        string GenerateJWTToken(IdentityUser user, List<string> roles);
        string GenerateRefreshToken();
        bool ValidateRefreshToken(string refreshToken);
    }
}
