using JWT.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(LoginDto user);
    }
}
