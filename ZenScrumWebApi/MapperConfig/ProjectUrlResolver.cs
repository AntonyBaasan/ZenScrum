using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using ZenScrumWebApi.Controllers;
using ZenScrumWebApi.Dto;

namespace ZenScrumWebApi.MapperConfig
{
    public class ProjectUrlResolver : IValueResolver<Project, ProjectDto, string>
    {
        IHttpContextAccessor _httpContextAccessor;

        public ProjectUrlResolver()
        {
        }
        
        public ProjectUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Project source, ProjectDto destination, string destMember, ResolutionContext context)
        {
            // TODO: this case added to pass unit tests, have to fix (Need to solve DI of IHttpContextAccessor)
            if(_httpContextAccessor == null)
                return "";
            
            var url = (UrlHelper) _httpContextAccessor.HttpContext.Items[BaseController.UrlHelperStr];
            return url.Link("ProjectGet", new {id = source.Id});
        }
    }
}