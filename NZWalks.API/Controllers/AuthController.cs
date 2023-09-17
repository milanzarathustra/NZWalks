using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Enums;
using NZWalks.API.Enums.Global;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Models.DTO.Auth.Response;
using NZWalks.API.Models.Shared;
using NZWalks.API.Repositories.Auth;
using NZWalks.API.Repositories.Token;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly AppSettings appSettings;
        private readonly ITokenRepository tokenRepository;
        private readonly IAuthRepository authRepository;

        public AuthController(UserManager<IdentityUser> userManager, AppSettings appSettings, ITokenRepository tokenRepository, IAuthRepository authRepository)
        {
            this.userManager = userManager;
            this.appSettings = appSettings;
            this.tokenRepository = tokenRepository;
            this.authRepository = authRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequestDto)
        {
            var response = await authRepository.Register(registerRequestDto);

            if (response.HasErrors)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var loginResponse = await authRepository.Login(loginRequest);

            if (loginResponse.HasErrors)
                return BadRequest(loginResponse);
            
            return Ok(loginResponse);
        }

        [HttpGet]
        [Route("UserExists/{userName}")]
        public async Task<IActionResult> UserExists([FromRoute] string userName)
        {
            var user = await authRepository.UserExists(userName);

            return Ok(await authRepository.UserExists(userName));
        }

        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> Refresh([FromRoute] RefreshRequestDto refreshRequestDto)
        {
            //bool isValidRefreshToken = tokenRepository.ValidateRefreshToken(refreshRequestDto.RefreshToken);

            //if (!isValidRefreshToken)
            //{
            //    return BadRequest(new ErrorResponse("Invalid Refresh Token"));
            //}

            //userManager.SetAuthenticationTokenAsync
        }
    }
}
