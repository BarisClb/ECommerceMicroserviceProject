using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Relations
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? ParentCategoryId { get; set; }
    }
}
