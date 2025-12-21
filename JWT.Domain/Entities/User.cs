using JWT.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Domain.Entities
{
    public class User : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
