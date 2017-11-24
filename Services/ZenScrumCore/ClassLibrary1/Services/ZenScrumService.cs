using System;
using System.Linq;
using Domain;
using ZenScrum.Utilities;
using DataRepository;

namespace ZenScrumCore.Services
{
    public class ZenScrumService : IZenScrumService
    {
        IDataRepository _repository;

        public ZenScrumService(IDataRepository repository)
        {
            _repository = repository;
        }

        public Project[] GetProjects()
        {
            //var projects = _repository.GetObjects<Project>();

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

        public void CreateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(int id, Project project)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }
    }
}