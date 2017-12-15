using MongoDB.Bson;
using System.Collections.Generic;

namespace Domain
{
    public class WorkItem : BaseObject
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public int Points { get; set; }
        public string Status { get; set; }
        public WorkItemType Type { get; set; }
        public List<Activity> History { get; set; }
        public List<string> Labels { get; set; }
        public List<Comment> Comments { get; set; }
        public ObjectId Iteration { get; set; }
        public ObjectId Project { get; set; }
    }
}