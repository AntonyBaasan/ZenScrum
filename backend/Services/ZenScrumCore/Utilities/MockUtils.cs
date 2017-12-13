using Domain;
using MongoDB.Bson;
using System.Collections.Generic;

namespace ZenScrum.Utilities
{
    public class MockUtils
    {
        public static List<Project> GetMockProjects()
        {
            return new List<Project>
            {
                new Project {Id = ObjectId.GenerateNewId(), Name = "Project1", Details = "This is a first project", Moniker = "1nd"},
                new Project {Id = ObjectId.GenerateNewId(), Name = "Project2", Details = "This is a 2nd project", Moniker = "2nd"},
                new Project {Id = ObjectId.GenerateNewId(), Name = "Project3", Details = "This is a 3rd project", Moniker = "3rd"}
            };
        }
    }
}
