
using JWT.Application.Dtos.ItemDtos;
using JWT.Application.Dtos.Order;
using JWT.Domain.Entities;

namespace JWT.Application.Dtos.OrderDtos
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long OrderId { get; set; }
        public decimal SalesPrice { get; set; }

        public decimal? ItemDiscount { get; set; }
        public int Quantity { get; set; }
    }
}
