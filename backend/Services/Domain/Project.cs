using MongoDB.Bson;
using System.Collections.Generic;

namespace Domain
{
    public class Project: BaseObject
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Moniker { get; set; }
        public bool IsPublic { get; set; }
        public List<ObjectId> Members { get; set; }
    }
}