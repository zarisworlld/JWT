using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Application.Dtos.ItemDtos
{
    public class ItemDto
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
    }
}
