using MongoDB.Bson.Serialization.Attributes;

namespace coreService
{
    public class skills
    {
        [BsonElement("name")]
        public string name {get;set;}
    }
}