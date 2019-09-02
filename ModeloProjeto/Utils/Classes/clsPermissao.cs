using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace MorarUrbanova.Utils.Classes
{
    public class clsPermissao
    {

        #region Propriedades
        const string Session_UsuarioLogado = "Sistema_UsuarioLogado";
        //public static DataTable DtUsuarioLogado
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Application[Session_UsuarioLogado] != null)
        //            return (HttpContext.Current.Application[Session_UsuarioLogado] as DataTable);
        //        else
        //            return null;
        //    }
        //    set
        //    {
        //        HttpContext.Current.Application[Session_UsuarioLogado] = value;
        //    }
        //}
        #endregion Propriedades

        #region Operação


        public static string SenhaADM(string sParametro)
        {
            ////Verifica senha ADM
            //if (string.IsNullOrEmpty(sParametro))
            //    return EncryptionLibraryBase.EncryptString("sem acesso");

            ////Obtém parâmetros
            //Queue<string> parametros = new Queue<string>(sParametro.Split('$'));
            //string sHora = parametros.Dequeue().PadLeft(2, '0');
            //string sDia = parametros.Dequeue().PadLeft(2, '0');
            //string sMes = parametros.Dequeue().PadLeft(2, '0');
            //string sAno = parametros.Dequeue().PadLeft(4, '0');
            //string sFixo = "MC";

            ////Prepara chave
            //string sTotal = sMes + sAno + sFixo + sHora + sDia;
            //string sCript = EncryptionLibraryBase.EncryptStringNoJunk(sTotal);

            ////Recorta se exceder
            //if (sCript.Length > 20)
            //    sCript = sCript.Substring(0, 20);

            //return sCript;
            return string.Empty;
        }

        #endregion
        #region Session
        public static string GerarTokenAcesso(long lID_USUR)
        {
            return string.Empty;
            ////Token de Acesso
            //DateTime oData = DateTime.Now;
            //string sResultado = lID_USUR
            //                        + oData.Year.ToString()
            //                        + oData.Month
            //                        + oData.Day
            //                        + oData.Hour
            //                        + oData.Minute
            //                        + oData.Second
            //                        + oData.Millisecond;
            //sResultado = EncryptionLibraryBase.EncryptString(sResultado);

            //clsUsuarioBS oUsuario = new clsUsuarioBS();
            //oUsuario.ID_USUR = lID_USUR;
            //oUsuario.TOKEN_USUR = sResultado;
            //string sResultProc = new clsUsuarioDAOBS().AlterarToken(oUsuario);
            ////clsSession.getSessionSistema(EnumSessionSistema.SistemaTokenacesso).ToString() = sResultado;
            //clsSessionBase.setSessionSistema(EnumSessionSistema.SistemaTokenacesso, sResultado);

            //return sResultado;
        }
        public static bool TokenValido()
        {
            return true;
            ////Valida tokenMO
            //clsUsuarioBS oUsuario = new clsUsuarioBS();
            //oUsuario.ID_USUR = (long)clsSessionBase.getSessionSistema(EnumSessionSistema.SistemaId_usur);
            //DataTable oDt = new clsUsuarioDAOBS().Obter(oUsuario);
            //return      (oDt != null)
            //        && (oDt.Rows.Count > 0)
            //        && (oDt.Rows[0]["TOKEN_USUR"] != null)
            //        && (oDt.Rows[0]["TOKEN_USUR"] != DBNull.Value)
            //        && (oDt.Rows[0]["TOKEN_USUR"].ToString() == clsSessionBase.getSessionSistema(EnumSessionSistema.SistemaTokenacesso).ToString());
        }
        public static void Logout()
        {
            //Desloga usuário
            //if (clsObject.hasValue(clsSession.getSessionSistema(EnumSessionSistema.SistemaId_usur)))
            //    RemoverUsuarioEmpresa((long)clsSession.getSessionSistema(EnumSessionSistema.SistemaId_usur), HttpContext.Current.Session.SessionID, HttpContext.Current.Application);
            //clsSessionBase.limparTodaSession();
        }
        public static void Redirect(Page oPagina, string sEndereco)
        {
            if (oPagina.IsCallback)
            {
                oPagina.Response.RedirectLocation = VirtualPathUtility.ToAbsolute(sEndereco);
                oPagina.Response.End();
            }
            else
                oPagina.Response.Redirect(sEndereco);

        }
        #endregion Session


    }
}
