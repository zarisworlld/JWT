using JWT.Api.ViewModels.Item;

namespace JWT.Api.ViewModels.Order
{
    public class OrderItemViewModel
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long OrderId { get; set; }
        public decimal SalesPrice { get; set; }

        public decimal? ItemDiscount { get; set; }
        public int Quantity { get; set; }
    }
}
