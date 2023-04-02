namespace BasketService.Application.Models.Requests
{
    public class UpdateBasketForItemRequest
    {
        public Guid UserId { get; set; }
        public string BasketItemId { get; set; }
        public string? BasketItemName { get; set; }
        public decimal? BasketItemPrice { get; set; }
        public int? BasketItemQuantity { get; set; }
    }
}
