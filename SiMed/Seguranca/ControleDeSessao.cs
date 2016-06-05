using SiMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SiMed.Seguranca
{
    public class ControleDeSessao
    {
        private const string USUARIO_LOGADO = "USUARIO_LOGADO";

        public static Usuario UsuarioLogado
        {
            get
            {
                return HttpContext.Current.Session[USUARIO_LOGADO] as Usuario;
            }
        }

        public static void CriarSessao(Usuario usuarioAutenticado)
        {
            var usuarioLogado = usuarioAutenticado;

            FormsAuthentication.SetAuthCookie(usuarioLogado.Email, true);

            HttpContext.Current.Session["USUARIO_LOGADO"] = usuarioLogado;
        }
    }
}