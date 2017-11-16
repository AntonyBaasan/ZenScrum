using System;
using System.Linq;
using Domain;
using ZenScrum.Utilities;

namespace ZenScrum.Services
{
    public class ZenScrumService : IZenScrumService
    {
        public ZenScrumService()
        {
        }

        public Project[] GetProjects()
        {
            return MockUtils.GetMockProjects();
        }

        public Project GetProjectByMoniker(string moniker)
        {
            return MockUtils.GetMockProjects().Single(p => p.Moniker == moniker);
        }

        public Project GetProjectById(int id)
        {
            return MockUtils.GetMockProjects().Single(p => p.Id == id);
        }
    }
}