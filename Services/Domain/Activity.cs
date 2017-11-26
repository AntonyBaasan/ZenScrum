using System;

namespace Domain
{
    public class Activity
    {
        public User Owner { get; set; }
        public string Action { get; set; }
        public DateTime When { get; set; }
    }
}