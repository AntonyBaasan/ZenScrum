using Domain;

namespace ZenScrum.Services
{
    public interface IZenScrumService
    {
        Project[] GetProjects();

        Project GetProjectByMoniker(string moniker);

        Project GetProjectById(int id);
    }
}