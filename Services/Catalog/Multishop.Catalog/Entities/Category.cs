using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //bir id olduğu uygulamaya bildirilmiş oldu.
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
