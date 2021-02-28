using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace JDPI.Common.Domain
{
    public class BaseEntity : IEntity
    {
        [BsonId]
        public ObjectId _Id;

    }
}
