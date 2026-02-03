using JWT.Api.ViewModels.Security;
using JWT.Application.Dtos.Security;
using JWT.Application.Interfaces.Security;
using JWT.Domain.Entities;
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

        [AllowAnonymous]
        [Route("TestLogin")]
        public async Task<IActionResult> TestLogin([FromBody] TestLoginViewModel model)
        {
            var loginUser = new TestLoginDto();
            loginUser.Password = model.password;
            loginUser.UserName = model.userName;
            string token = string.Empty;
            if (await this._authService.TestValidateUser(loginUser))
            {
                var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.Name,loginUser.UserName)
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