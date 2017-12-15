using DataRepository;
using Domain;

namespace ZenScrumCore.Services
{
    public interface IZenScrumService
    {
        IDataRepository<Project> ProjectRepository { get; }
        IDataRepository<Iteration> IterationRepository { get; }
        IDataRepository<WorkItem> WorkItemRepository { get; }
    }
}