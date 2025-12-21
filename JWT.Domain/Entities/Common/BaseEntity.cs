using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Domain.Entities.Common
{
    public class BaseEntity<T>
    {
        public required T Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
