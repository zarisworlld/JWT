using JWT.Application.Dtos.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Interfaces.Security
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(LoginDto user);
        Task<bool> ValidateUserWithToken(string Token);
    }
}
