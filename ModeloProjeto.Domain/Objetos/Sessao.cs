using System.Web;

namespace ModeloProjeto.Domain.Objetos
{
    public static class Sessao
    {
        public static long GetUsuarioId() => long.Parse(HttpContext.Current.Session["ID_USUARIO"].ToString());
        public static long GetToken() => long.Parse(HttpContext.Current.Session["TOKEN_USUARIO"].ToString());
    }
}