using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace JWT.Application.Interfaces
{
    public interface ITokenService
    {
        (string token, DateTime expires) CreateAccessTokenWithExpiry(IEnumerable<Claim> claims);
        string CreateAccessToken(IEnumerable<Claim> claims);
    }
}
