using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ModeloProjeto.Controllers
{
    public class BaseController : ApiController
    {

        public BaseController()
        {
        }
        public long? IdUsuario { get; set; } = HttpContext.Current.Session.Count > 0 ? long.Parse(HttpContext.Current.Session["ID_USUARIO"].ToString()) : 0;
        public string Token { get; set; } = HttpContext.Current.Session.Count > 0 ? HttpContext.Current.Session["TOKEN_USUARIO"]?.ToString() : null;

        //public bool IsTokenValido()
        //{
        //    TipoErroRequisicao erro;
        //    var token = usuarioAppService.BuscarUltimoToken(IdUsuario ?? default(long));

        //    if (IdUsuario == null)
        //        erro = TipoErroRequisicao.NaoLogado;
        //    else
        //        erro = token != Token ? TipoErroRequisicao.TokenInvalido : TipoErroRequisicao.Nenhum;

        //    return erro == TipoErroRequisicao.Nenhum ? true : false;

        //}

        public void GravarCookie(/*Usuario usuario*/)
        {
            //HttpCookie cookie = HttpContext.Current.Request.Cookies["ModeloProjeto"];
            //if (cookie == null)
            //{
            //    cookie = new HttpCookie("ModeloProjeto");

            //    cookie.Values.Add(nameof(usuario), Json(usuario).ToString());

            //    cookie.Expires = DateTime.Now.AddDays(365);

            //    cookie.HttpOnly = true;

            //    HttpContext.Current.Response.AppendCookie(cookie);
            //}
        }

        public void GravarSessao(/*Usuario usuario*/)
        {
            //HttpContext.Current.Session.Clear();
            //HttpContext.Current.Session.Add("USUARIO", usuario);
            //HttpContext.Current.Session.Add("ID_USUARIO", usuario.Id);
            //HttpContext.Current.Session.Add("TOKEN_USUARIO", usuario.Token);
        }
    }
}