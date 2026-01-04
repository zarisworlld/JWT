using JWT.Application.Dtos.Security;
using JWT.Application.Interfaces.Security;
using JWT.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT.Infrastructure.DomainServices.SecurityDomainService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthService(AppDbContext dbContext,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<bool> ValidateUser(LoginDto loginUser)
        {
            return await _dbContext.Users.AnyAsync(c => c.Id == loginUser.UserId && c.Name == loginUser.UserName && c.Role == loginUser.Role && c.Password == loginUser.Password);
        }
        public async Task<bool> ValidateUserWithToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];
            try
            {
                handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out var securityToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}