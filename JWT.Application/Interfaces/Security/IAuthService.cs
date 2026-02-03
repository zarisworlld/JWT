using JWT.Application.Dtos.Security;
using JWT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Interfaces.Security
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(LoginDto user);
        Task<bool> ValidateUserWithToken(string Token);
        Task<bool> TestValidateUser(TestLoginDto model);
        Task SaveUsers(List<TestLoginDto> users);
    }
}
