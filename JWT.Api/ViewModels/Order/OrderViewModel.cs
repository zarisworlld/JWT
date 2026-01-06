using JWT.Domain.Entities;

namespace JWT.Api.ViewModels.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public decimal PayablePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public ICollection<OrderItemViewModel> OrderItems { get; set; } = [];
    }
}
