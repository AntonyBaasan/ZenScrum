using Domain;
using Microsoft.AspNetCore.Http;
using ZenScrumWebApi.Dto;

namespace ZenScrumWebApi.MapperConfig
{
    public class WorkItemUrlResolver: BaseUrlResolver<WorkItem, WorkItemDto>
    {
        public WorkItemUrlResolver(): base()
        {
            UrlGetLinkName = "WorkItemGet";
        }
        
        public WorkItemUrlResolver(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
        {
            UrlGetLinkName = "WorkItemGet";
        }
    }
}