using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace list.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; } = null;

        [BsonElement("Done")]
        [BsonDefaultValue(false)]
        public bool? Done { get; set; } = null;
       

    }
}
