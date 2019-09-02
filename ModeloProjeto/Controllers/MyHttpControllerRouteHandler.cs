using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;

namespace ModeloProjeto.Controllers
{
    public class MyHttpControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MyHttpControllerHandler(requestContext.RouteData);
        }
    }
}