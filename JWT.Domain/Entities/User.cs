using JWT.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Domain.Entities
{
    public class User : BaseEntity<long>
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
