
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JDPI.Common.Domain
{
    public class BaseEntity : IEntity
    {
        [BsonId]
        public ObjectId _id { get; set; }
    }
}