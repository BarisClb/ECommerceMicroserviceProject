namespace BasketService.Application.Models.Entities
{
    public class Basket
    {
        public Guid UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public decimal TotalPrice
        {
            get => Items?.Sum(item => item.Price * item.Quantity) ?? 0.00M;
        }
    }
}
