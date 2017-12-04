using System.Linq;
using Domain;
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
            return _repository.GetObjects<Project>().ToArray();
        }

        public Project GetProjectByMoniker(string moniker)
        {
            return _repository.GetObjects<Project>().Single(p => p.Moniker == moniker);
        }

        public Project GetProjectById(string id)
        {
            return _repository.GetObjectById<Project>(id);
        }

        public void CreateProject(Project project)
        {
            _repository.Create(project);
        }

        public void UpdateProject(string id, Project project)
        {
            _repository.Update(id, project);
        }

        public void DeleteProject(string id)
        {
            _repository.Delete<Project>(id);
        }
    }
}