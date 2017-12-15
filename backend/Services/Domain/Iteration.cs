using System;

namespace Domain
{
    public class Iteration : BaseObject
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}