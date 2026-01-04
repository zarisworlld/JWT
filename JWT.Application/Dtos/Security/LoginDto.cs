using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Dtos.Security
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
