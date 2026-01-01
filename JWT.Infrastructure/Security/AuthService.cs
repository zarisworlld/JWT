using JWT.Application.Dtos;
using JWT.Application.Interfaces;
using JWT.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWT.Infrastructure.Security
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;
        public AuthService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ValidateUser(LoginDto loginUser)
        {
            return await _dbContext.Users.AnyAsync(c => c.Id == loginUser.UserId && c.Name == loginUser.UserName && c.Role == loginUser.Role && c.Password == loginUser.Password);
        }
        public async Task<bool> ValidateUserWithToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);

            Int64.TryParse(jwtToken.Claims.FirstOrDefault(x => x.Type == "Sub")?.Value,out long userId);
            var userName = jwtToken.Claims.FirstOrDefault(x => x.Type == "Name")?.Value;
            var role = jwtToken.Claims.FirstOrDefault(x => x.Type == "Role")?.Value;
            return await _dbContext.Users.AnyAsync(c => c.Id == userId && c.Name == userName && c.Role == role);
        }
    }
}