using Domain;
using System.Collections.Generic;

namespace ZenScrumWebApi.Dto
{
    public class WorkItemDto : BaseDto
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public int Points { get; set; }
        public string Status { get; set; }
        public WorkItemType Type { get; set; }
        public List<Activity> History { get; set; }
        public List<string> Labels { get; set; }
        public List<Comment> Comments { get; set; }
        public string IterationId { get; set; }
        public string ProjectId { get; set; }
        public List<WorkItem> Children { get; set; }
    }
}