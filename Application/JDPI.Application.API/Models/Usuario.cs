using System;
using MongoDB.Bson.Serialization.Attributes;

namespace JDPI.Application.API.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CrationDate { get; set; }
    }
}