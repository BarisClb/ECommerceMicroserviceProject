using MongoDB.Bson.Serialization.Attributes;
using ProductService.Domain.Helpers;

namespace ProductService.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        // Relations
        public ProductCategory ProductCategory { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string SellerId { get; set; }
    }
}
