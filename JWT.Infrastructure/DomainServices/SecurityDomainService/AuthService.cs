using JWT.Application.Dtos.Security;
using JWT.Application.Interfaces.Security;
using JWT.Domain.Context;
using JWT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace JWT.Infrastructure.DomainServices.SecurityDomainService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly string jsonFile = "users.json";
        public AuthService(AppDbContext dbContext,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<bool> TestValidateUser(TestLoginDto model)
        {
            List<TestLoginDto> models;
    
            if (System.IO.File.Exists(jsonFile))
            {
                var jsonData = await System.IO.File.ReadAllTextAsync(jsonFile);
                models = JsonSerializer.Deserialize<List<TestLoginDto>>(jsonData) ?? new List<TestLoginDto>();
            }
            else
            {
                models = new List<TestLoginDto>(); 
            }
    
            var existingUser = models.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);
    
            if (existingUser != null)
            {
                return true; 
            }
            else
            {
                models.Add(new TestLoginDto { UserName = model.UserName, Password = model.Password });
    
                await this.SaveUsers(models);
    
                return true; 
            }
        }
        public async Task SaveUsers(List<TestLoginDto> users)
        {
            var jsonData = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            await System.IO.File.WriteAllTextAsync(jsonFile, jsonData);
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