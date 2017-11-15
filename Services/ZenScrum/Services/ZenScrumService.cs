using System;
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
            throw new NotImplementedException();
        }

        public Project GetProjectById(int id)
        {
            return null;
        }

    }
}