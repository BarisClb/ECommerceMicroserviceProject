namespace ProductService.Application.Models.Requests
{
    public class CategoryUpdateRequest
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ParentCategoryId { get; set; }
    }
}
