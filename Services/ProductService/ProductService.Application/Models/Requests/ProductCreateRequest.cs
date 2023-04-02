namespace ProductService.Application.Models.Requests
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Relations
        public string? CategoryId { get; set; }

        public string SellerId { get; set; }
    }
}
