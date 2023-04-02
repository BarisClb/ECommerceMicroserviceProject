using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Application.Models.Requests
{
    public class ProductUpdateRequest
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Image { get; set; }

        // Relations
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? SellerId { get; set; }
    }
}
