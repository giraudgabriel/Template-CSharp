using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace ModeloProjeto.Controllers
{
    public class MyHttpControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public MyHttpControllerHandler(RouteData routeData)
            : base(routeData)
        {
        }
    }
}