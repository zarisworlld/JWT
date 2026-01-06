namespace JWT.Api.ViewModels.Order
{
    public class OrderItemViewModel
    {
        public long ItemId { get; set; }
        public long OrderId { get; set; }
        public decimal SalesPrice { get; set; }

        public decimal? ItemDiscount { get; set; }
        public int Quantity { get; set; }
    }
}
