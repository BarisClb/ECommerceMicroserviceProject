namespace ProductService.Application.Models.Requests
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ParentCategoryId { get; set; }
    }
}
