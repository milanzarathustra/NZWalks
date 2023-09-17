using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Models.Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repositories.Auth
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AuthenticationConfiguration configuration;

        public TokenRepository(AuthenticationConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateJWTToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return GenerateToken(
                configuration.AccessTokenSecret, 
                configuration.Issuer, 
                configuration.Audience, 
                configuration.AccessTokenExpirationMinutes, 
                claims);
        }

        public string GenerateRefreshToken()
        {
            return GenerateToken(
                configuration.RefreshTokenSecret,
                configuration.Issuer,
                configuration.Audience,
                configuration.RefreshTokenExpirationMinutes);
        }

        public bool ValidateRefreshToken(string refreshToken)
        {
            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.Issuer,
                ValidAudience = configuration.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration.RefreshTokenSecret)),
                ClockSkew = TimeSpan.Zero
            };

            var handler = new JwtSecurityTokenHandler();

            try
            {
                handler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);

                return true;

            } catch (Exception ex)
            {
                throw new Exception("Could not Validate the Refresh Token");
            }     
        }

        #region Helpers 

        private string GenerateToken(
            string secretKey,
            string issuer,
            string audience,
            double expirationMinutes,
            IEnumerable<Claim>? claims = null)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}
