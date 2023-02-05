namespace ProductService.Application.Models.Request
{
    public class ProductCategoryUpdateRequest
    {
        public string ProductId { get; set; }
        public string? CategoryId { get; set; }
    }
}
