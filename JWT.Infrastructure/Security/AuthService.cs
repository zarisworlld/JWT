using JWT.Application.Dtos;
using JWT.Application.Interfaces;
using JWT.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
