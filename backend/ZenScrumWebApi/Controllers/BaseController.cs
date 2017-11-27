using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ZenScrumWebApi.Controllers
{
    public abstract class BaseController: Controller
    {
        public const string UrlHelperStr = "URLHELPER";
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            
            //save this.url inside the context to use it somewhere later
            context.HttpContext.Items[UrlHelperStr] = this.Url;
        }
    }
}