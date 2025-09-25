using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Multishop.Catalog.Entities
{
    public class FeatureSlider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //bir id olduğu uygulamaya bildirilmiş oldu.
        public string FeatureSliderId { get; set; }
        public string Title { get; set; }
        public string Descriptiom { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

    }
}
