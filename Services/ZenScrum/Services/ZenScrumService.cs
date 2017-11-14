using System;
using Domain;

namespace ZenScrum.Services
{
    public class ZenScrumService : IZenScrumService
    {
        public ZenScrumService()
        {
        }

        public Project[] GetProjects()
        {
            return GetMockProjects();
        }

        public Project GetProjectByMoniker(string moniker)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(int id)
        {
            return null;
        }

        private Project[] GetMockProjects()
        {
            return new Project[]
            {
                new Project {Id = 1, Name = "Project1", Details = "This is a first project", Moniker = "1nd"},
                new Project {Id = 2, Name = "Project2", Details = "This is a 2nd project", Moniker = "2nd"},
                new Project {Id = 3, Name = "Project3", Details = "This is a 3rd project", Moniker = "3rd"}
            };
        }
    }
}