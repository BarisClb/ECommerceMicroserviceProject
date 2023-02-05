using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Domain.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
