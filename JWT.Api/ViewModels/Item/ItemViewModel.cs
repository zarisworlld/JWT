namespace JWT.Api.ViewModels.Item
{
    public class ItemViewModel
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public required string Title { get; set; }
        public decimal Price { get; set; }
    }
}
