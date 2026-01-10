using JWT.Application.Dtos.OrderDtos;
using JWT.Domain.Entities;

namespace JWT.Api.ViewModels.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal PayablePrice { get; set; }
        public decimal? DiscountPrice { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; } = new();
    }
}
