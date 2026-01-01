using JWT.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Domain.Entities
{
    public class Item : BaseEntity<long>
    {
        public required string Title { get; set; }
        public decimal Price { get; set; }
    }
}
