using SiMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SiMed.Seguranca
{
    public class Autorizador : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Usuario usuario = ControleDeSessao.UsuarioLogado;

            var httpContext = filterContext.HttpContext;

            bool temAutorizacao = AuthorizeCore(httpContext);
            bool temSession = usuario != null;

            if (temSession && temAutorizacao)
            {
                string[] roles = new string[1];
                roles[0] = usuario.Permissao.ToString();

                var identidade = new GenericIdentity(usuario.Email);
                var principal = new GenericPrincipal(identidade, roles);

                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

                base.OnAuthorization(filterContext);
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}