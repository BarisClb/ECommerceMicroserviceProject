using MongoDB.Bson.Serialization.Attributes;
using ProductService.Domain.Helpers;

namespace ProductService.Application.Models.Responses
{
    public class ProductResponse
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        // Relations
        public ProductCategory ProductCategory { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string SellerId { get; set; }
    }
}
