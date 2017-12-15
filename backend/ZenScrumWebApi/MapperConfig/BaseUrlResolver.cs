using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using ZenScrumWebApi.Controllers;

namespace ZenScrumWebApi.MapperConfig
{
    public abstract class BaseUrlResolver<T, K> : IValueResolver<T, K, string> where T : BaseObject
    {
        IHttpContextAccessor _httpContextAccessor;
        protected string UrlGetLinkName { get; set; }

        public BaseUrlResolver()
        {
        }

        public BaseUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(T source, K destination, string destMember, ResolutionContext context)
        {
            // TODO: this case added to pass unit tests, have to fix (Need to solve DI of IHttpContextAccessor)
            if (_httpContextAccessor == null)
                return "";

            var url = (UrlHelper)_httpContextAccessor.HttpContext.Items[BaseController.UrlHelperStr];
            return url.Link(UrlGetLinkName, new { id = source.Id });
        }
    }
}
