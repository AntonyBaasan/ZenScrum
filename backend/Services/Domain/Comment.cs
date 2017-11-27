using System;

namespace Domain
{
    public class Comment
    {
        public User Writer { get; set; }
        public DateTime Created { get; set; }
    }
}