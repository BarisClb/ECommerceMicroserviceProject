namespace ProductService.Application.Models.Request
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ParentCategoryId { get; set; }
    }
}
