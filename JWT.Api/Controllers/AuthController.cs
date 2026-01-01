using JWT.Api.ViewModels;
using JWT.Application.Dtos;
using JWT.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Login([FromBody] LoginRequest user)
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