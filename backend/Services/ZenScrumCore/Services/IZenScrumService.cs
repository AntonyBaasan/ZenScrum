using Domain;

namespace ZenScrumCore.Services
{
    public interface IZenScrumService
    {
        Project[] GetProjects();

        Project GetProjectByMoniker(string moniker);

        Project GetProjectById(string id);

        void CreateProject(Project project);

        void UpdateProject(string id, Project project);

        void DeleteProject(string id);
    }
}