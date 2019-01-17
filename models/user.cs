using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace coreService
{
    public class user
    {
        [BsonElement("name")]
        public string name {get;set;}
        [BsonElement("email")]
        public string email {get;set;}
        [BsonElement("age")]
        public int age {get;set;}
        [BsonElement("skills")]
        public skills skills {get;set;}
    }
}