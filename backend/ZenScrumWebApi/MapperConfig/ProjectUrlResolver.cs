using Domain;
using Microsoft.AspNetCore.Http;
using ZenScrumWebApi.Dto;

namespace ZenScrumWebApi.MapperConfig
{
    public class ProjectUrlResolver: BaseUrlResolver<Project, ProjectDto>
    {
        public ProjectUrlResolver(): base()
        {
            UrlGetLinkName = "ProjectGet";
        }
        
        public ProjectUrlResolver(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            UrlGetLinkName = "ProjectGet";
        }
    }
}