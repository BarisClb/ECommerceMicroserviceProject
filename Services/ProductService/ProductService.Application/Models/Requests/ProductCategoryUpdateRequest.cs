namespace ProductService.Application.Models.Requests
{
    public class ProductCategoryUpdateRequest
    {
        public string ProductId { get; set; }
        public string? CategoryId { get; set; }
    }
}
