using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Enums.Global;
using NZWalks.API.Enums;
using NZWalks.API.Models.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NZWalks.API.Models.DTO.Auth.Response;
using NZWalks.API.Models.DTO.Auth.Request;

namespace NZWalks.API.Repositories.Token
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AuthenticationConfiguration configuration;
        private readonly AppSettings appSettings;
        private readonly UserManager<IdentityUser> userManager;

        public TokenRepository(
            AuthenticationConfiguration configuration, 
            AppSettings appSettings, 
            UserManager<IdentityUser> userManager
            )
        {
            this.configuration = configuration;
            this.appSettings = appSettings;
            this.userManager = userManager;
        }

        public async Task<JwtAuthResponseViewModel> GenerateTokens(IdentityUser user)
        {
            var claims = await GetUserClaims(user);

            var jwtToken = new JwtSecurityToken(
                configuration.Issuer,
                configuration.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(configuration.AccessTokenExpirationMinutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.AccessTokenSecret)), SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var refreshToken = await userManager.GenerateUserTokenAsync(user, appSettings.AppName, ApplicationSettingsEnum.RefreshToken.GetEnumMemberValue() ?? "");

            var refreshTokenModel = new RefreshTokenResponseViewModel
            {
                UserName = user.Email,
                TokenString = refreshToken,
                ExpireAt = DateTime.Now.AddMinutes(configuration.RefreshTokenExpirationMinutes)
            };

            return new JwtAuthResponseViewModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenModel
            };
        }

        public async Task<JwtAuthResponseViewModel?> RefreshTokens(RefreshRequest refreshRequest)
        {
            var user = await userManager.FindByEmailAsync(refreshRequest.Email);

            if (user == null)
                return null;

            var isValid = await userManager.VerifyUserTokenAsync(
                user, 
                appSettings.AppName,
                ApplicationSettingsEnum.RefreshToken.GetEnumMemberValue() ?? "", 
                refreshRequest.RefreshToken);

            if (!isValid)
            {
                return null;
            }
            
            return await GenerateTokens(user);
        }

        public async Task<IEnumerable<Claim>> GetUserClaims(IdentityUser user)
        {
            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (roles.Any())
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            return claims;
        }
    }
}
