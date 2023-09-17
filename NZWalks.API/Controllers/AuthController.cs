using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Models.DTO.Auth.Response;
using NZWalks.API.Models.Shared;
using NZWalks.API.Repositories.Auth;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var user = await userManager.FindByEmailAsync(registerRequestDto.Username);

            if (user != null) 
            {
                return Conflict("User already exists");
            }

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                //In Trainer app we will default roles here instead of doing it from the api
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok($"{identityUser.UserName} was registered!"); //Might be better to return object here and in this complete method (look at other methods too)
                    }
                }
            } 
            else
            {
                return BadRequest(identityResult.Errors);
            }

            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null) 
            { 
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    
                    if (roles != null)
                    {
                        var authToken = tokenRepository.GenerateJWTToken(user, roles.ToList());
                        var refreshToken = tokenRepository.GenerateRefreshToken();

                        var response = new LoginResponseDto
                        {
                            AuthenticationToken = authToken,
                            RefreshToken = refreshToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password was Incorrect");
        }

        [HttpGet]
        [Route("UserExists/{userName}")]
        public async Task<IActionResult> UserExists([FromRoute] string userName)
        {
            var user = await userManager.FindByEmailAsync(userName);

            var userExistsResponse = new UserExistsResponseDto
            {
                Username = userName,
                Exists = user != null
            };

            return Ok(userExistsResponse);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromRoute] RefreshRequestDto refreshRequestDto)
        {
            bool isValidRefreshToken = tokenRepository.ValidateRefreshToken(refreshRequestDto.RefreshToken);

            if (!isValidRefreshToken)
            {
                return BadRequest(new ErrorResponse("Invalid Refresh Token"));
            }

            userManager.SetAuthenticationTokenAsync
        }
    }
}
