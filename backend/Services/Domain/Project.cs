using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Project: BaseObject
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Moniker { get; set; }
        public bool IsPublic { get; set; }
    }
}