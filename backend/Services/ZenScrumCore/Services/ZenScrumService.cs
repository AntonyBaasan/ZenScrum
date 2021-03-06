﻿using Domain;
using DataRepository;

namespace ZenScrumCore.Services
{
    /*
     * Implementation of Unit Of Work. 
     * Because we use MongoDB database for now we don't need Save method.
     * https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
     */

    public class ZenScrumService : IZenScrumService
    {
        public ZenScrumService(IDataRepository<Project> projectRepository, IDataRepository<Iteration> iterationRepository, IDataRepository<WorkItem> workItemRepository)
        {
            ProjectRepository = projectRepository;
            IterationRepository = iterationRepository;
            WorkItemRepository = workItemRepository;
        }

        public IDataRepository<Project> ProjectRepository { get; }

        public IDataRepository<Iteration> IterationRepository { get; }

        public IDataRepository<WorkItem> WorkItemRepository {get;}

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