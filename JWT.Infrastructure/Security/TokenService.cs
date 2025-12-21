using JWT.Application.Interfaces;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace JWT.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public (string token, DateTime expires) CreateAccessTokenWithExpiry(IEnumerable<Claim> claims)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var minutes = int.Parse(_config["Jwt:AccessTokenExpirationMinutes"]);
            var securityKey = _config["Jwt:Key"];
            var key = Encoding.UTF8.GetBytes(securityKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(minutes);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return (token, expires);

        }
        public string CreateAccessToken(IEnumerable<Claim> claims)
        {
            return CreateAccessTokenWithExpiry(claims).token;
        }
    }
}
