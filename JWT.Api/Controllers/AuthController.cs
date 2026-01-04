using JWT.Api.ViewModels.Security;
using JWT.Application.Dtos.Security;
using JWT.Application.Interfaces.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;
        public AuthController(ITokenService tokenService,IAuthService authService)
        {
            _tokenService = tokenService;
            _authService = authService;
        }
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            var loginUser = new LoginDto();
            loginUser.UserId = user.UserId;
            loginUser.Password = user.Password;
            loginUser.Role = user.Role;
            loginUser.UserName = user.UserName;
            string token = string.Empty;
            if(await this._authService.ValidateUser(loginUser))
            {
                var claims = new List<Claim>
               {
                   new Claim(JwtRegisteredClaimNames.Sub,loginUser.UserId.ToString()),
                   new Claim(ClaimTypes.Name,loginUser.UserName),
                   new Claim(ClaimTypes.Role,loginUser.Role)
               };
               token = _tokenService.CreateAccessToken(claims);
               return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}