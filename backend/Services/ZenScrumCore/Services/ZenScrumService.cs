using Domain;
using DataRepository;

namespace ZenScrumCore.Services
{
    /*
     * Implementation of Unit Of Work
     * https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
     */

    public class ZenScrumService : IZenScrumService
    {
        private IDataRepository<Project> _projectRepository;
        private IDataRepository<Iteration> _iterationRepository;

        public ZenScrumService(IDataRepository<Project> projectRepository, IDataRepository<Iteration> iterationRepository)
        {
            _projectRepository = projectRepository;
            _iterationRepository = iterationRepository;
        }

        public IDataRepository<Project> ProjectRepository => _projectRepository;

        public IDataRepository<Iteration> IterationRepository => _iterationRepository;

        //public Project[] GetProjects()
        //{
        //    return _repository.GetObjects<Project>().ToArray();
        //}

        //public Project GetProjectByMoniker(string moniker)
        //{
        //    return _repository.GetObjects<Project>().Single(p => p.Moniker == moniker);
        //}

        //public Project GetProjectById(string id)
        //{
        //    return _repository.GetObjectById<Project>(id);
        //}

        //public void CreateProject(Project project)
        //{
        //    _repository.Create(project);
        //}

        //public void UpdateProject(string id, Project project)
        //{
        //    _repository.Update(id, project);
        //    project.Id = ObjectId.Parse(id);
        //}

        //public void DeleteProject(string id)
        //{
        //    _repository.Delete<Project>(id);
        //}
    }
}