using ModeloProjeto.Controllers;
using MorarUrbanova.Utils.Classes;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ModeloProjeto
{
    public class Global : HttpApplication
    {
        #region Eventos
        protected void Application_Start(object sender, EventArgs e)
        {
            var route = RouteTable.Routes.MapHttpRoute(
                          name: "AutenticacaoApi",
                          routeTemplate: "Web/App/Services/{controller}/{action}/{id}",
                          defaults: new { id = RouteParameter.Optional }
                      );

            route.RouteHandler = new MyHttpControllerRouteHandler();

            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter()
            {
                SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            });
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        private string ToIgnore<T>(string method) where T : class
        {
            string controllerName = typeof(T).Name.Replace("Controller", "");
            string requestPath = controllerName + "/" + method;
            return requestPath.ToLower();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string[] rotasParaIgnorarVerificacao = {
            };

            string requestPath = HttpContext.Current.Request.Path.ToLower();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                string abaAtual = string.Empty;
                try
                {
                    abaAtual = HttpContext.Current.Request.Url.ToString(); //MorarUrbanova.Context.AbaAtual;
                }
                catch { }
                if (!Response.IsRequestBeingRedirected)
                {
                    HttpContext httpCurrent = HttpContext.Current;
                    Exception eErro = httpCurrent.Server.GetLastError();

                    Regex rgx = new Regex("[^a-zA-Z0-9 -]");

                    string sErro = HttpUtility.UrlEncode(eErro.Message.Replace("'", " ").Replace("\"", " ").Replace("$", " ").Replace("&#39;", " ")).Replace("&#39;", " ");
                    string sErroBase = HttpUtility.UrlEncode(eErro.GetBaseException().Message.Replace("'", " ").Replace("\"", " ").Replace("$", " ").Replace("&#39;", " ")).Replace("&#39;", " ");
                    sErro = rgx.Replace(sErro, " ");
                    sErroBase = rgx.Replace(sErroBase, " ");


                    httpCurrent.Server.ClearError();
                    httpCurrent.Response.Redirect("~/MensagemErro/Erro.htm?local=" + abaAtual + "&erro=" + sErro + "&erroInt=" + sErroBase);
                }
            }
            catch (Exception) { }
        }
        protected void Session_End(object sender, EventArgs e)
        {
            clsPermissao.Logout();
        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
        #endregion Eventos
    }
}