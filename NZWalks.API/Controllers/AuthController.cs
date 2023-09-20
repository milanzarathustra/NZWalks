using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO.Auth.Request;
using NZWalks.API.Repositories.Auth;
using NZWalks.API.Repositories.Token;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository tokenRepository;
        private readonly IAuthRepository authRepository;

        public AuthController( 
            ITokenRepository tokenRepository, 
            IAuthRepository authRepository)
        {
            this.tokenRepository = tokenRepository;
            this.authRepository = authRepository;
        }

        [HttpGet]
        [Route("UserExists/{userName}")]
        public async Task<IActionResult> UserExists([FromRoute] string userName)
        {
            return Ok(await authRepository.UserExists(userName));
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

        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> Refresh(RefreshRequest refreshRequest)
        {
            var refreshReponse = await tokenRepository.RefreshTokens(refreshRequest);

            if (refreshReponse == null)
                return BadRequest("Not Valid");

            return Ok(refreshReponse);
        }
    }
}
