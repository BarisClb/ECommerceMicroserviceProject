using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Domain.Helpers
{
    public class ProductCategory
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
