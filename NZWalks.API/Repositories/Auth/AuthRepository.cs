using Microsoft.AspNetCore.Identity;
using NZWalks.API.Enums.Global;
using NZWalks.API.Enums;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Models.DTO.Auth.Response;
using NZWalks.API.Models.Shared;
using NZWalks.API.Repositories.Token;
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
            var user = await userManager.FindByEmailAsync(loginRequest.Username);

            if (user == null)
                throw new Exception("Fatel: Could not find user");

            var result = await signInManager.CheckPasswordSignInAsync(
                user,
                loginRequest.Password,
                false);            

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

            var jwtResult = await tokenRepository.GenerateTokens(user);

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

        public Task<IEnumerable<IdentityUser>?> GetAllAsync(Query? query)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(IdentityUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, IdentityUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id, bool shadowDelete = true)
        {
            throw new NotImplementedException();
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
