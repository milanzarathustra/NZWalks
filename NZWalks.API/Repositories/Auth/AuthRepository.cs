﻿using Microsoft.AspNetCore.Identity;
using NZWalks.API.Enums.Global;
using NZWalks.API.Enums;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Models.DTO.Auth.Response;
using NZWalks.API.Models.Shared;
using NZWalks.API.Repositories.Token;
using System.Security.Claims;
using NZWalks.API.Models.DTO.Shared;

namespace NZWalks.API.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppSettings appSettings;
        private readonly ITokenRepository tokenRepository;

        public AuthRepository(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AppSettings appSettings,
            ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appSettings = appSettings;
            this.tokenRepository = tokenRepository;
        }

        public async Task<LoginResponseViewModel> Login(LoginRequest loginRequest)
        {
            var result = await signInManager.PasswordSignInAsync(
                loginRequest.Username,
                loginRequest.Password,
                false,
                false);

            var user = await userManager.FindByEmailAsync(loginRequest.Username);

            if (!result.Succeeded)
            {
                return new LoginResponseViewModel
                {
                    HasErrors = true,
                    Errors = new List<Error>()
                    {
                        new Error()
                        {
                            Code = Guid.NewGuid(),
                            Description = "Username or Password is Incorrect"
                        }
                    }
                };
            }

            if (user == null)
                throw new Exception("Fatel: Could not find user");

            var userClaims = await GetUserClaims(user);

            var jwtResult = await tokenRepository.GenerateToken(user, userClaims);

            await userManager.SetAuthenticationTokenAsync(
                user,
                appSettings.AppName,
                EnumMemberNames.GetEnumMemberValue(ApplicationSettingsEnum.RefreshToken)
                    ?? "",
                jwtResult.RefreshToken.TokenString);

            return new LoginResponseViewModel
            {
                AuthenticationToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            };
        }

        public async Task<LoginResponseViewModel> Register(RegisterRequest registerRequest)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Username
            };

            var userExistsModel = await UserExists(identityUser.UserName);

            if (userExistsModel.Exists)
            {
                return new LoginResponseViewModel
                {
                    HasErrors = true,
                    Errors = new List<Error>()
                    {
                        new Error()
                        {
                            Code = Guid.NewGuid(),
                            Description = "It seems as though you have an account already, please Login"
                        }
                    }
                };
            }

            var identityResult = await userManager.CreateAsync(
                identityUser,
                registerRequest.Password);

            if (identityResult.Succeeded)
            {
                //In Trainer app we will default roles here instead of doing it from the api
                var roles = registerRequest.Roles != null && registerRequest.Roles.Any() ? registerRequest.Roles : new string[0];

                identityResult = await userManager.AddToRolesAsync(identityUser, roles);

                if (identityResult.Succeeded)
                {
                    var loginRequest = new LoginRequest
                    {
                        Username = registerRequest.Username,
                        Password = registerRequest.Password
                    };

                    var loginResponse = await Login(loginRequest);

                    if (loginResponse == null)
                        throw new Exception("Fatel: Issue with logging in user after Registering");

                    return loginResponse;
                }
            }

            return Errors(identityResult);
        }

        public async Task<UserExistsResponseViewModel> UserExists(string userName)
        {
            var user = await userManager.FindByEmailAsync(userName);

            return new UserExistsResponseViewModel
            {
                Username = userName,
                Exists = user != null
            };
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

        #region Helpers 

        private static LoginResponseViewModel Errors(IdentityResult identityResult)
        {
            var loginResponseViewModel = new LoginResponseViewModel();
            loginResponseViewModel.HasErrors = true;

            foreach (var error in identityResult.Errors)
            {
                loginResponseViewModel.Errors = new List<Error>()
                {
                   new Error()
                   {
                       Code = Guid.NewGuid(),
                       Description = error.Description
                   }
                };
            }

            return loginResponseViewModel;
        }

        #endregion
    }
}
