using Domain;

namespace ZenScrumCore.Services
{
    public interface IZenScrumService
    {
        Project[] GetProjects();

        Project GetProjectByMoniker(string moniker);

        Project GetProjectById(int id);

        void CreateProject(Project project);

        void UpdateProject(int id, Project project);

        void DeleteProject(int id);
    }
}