using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repositories.Auth
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
