using SiMed.Models;
using SiMed.Seguranca;
using SiMed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiMed.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var autenticador = new AutenticacaoService();

                Usuario usuario = autenticador.BuscarPorAutenticacao(model.Login, model.Senha);

                if (usuario != null)
                {
                    ControleDeSessao.CriarSessao(usuario);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("INVALID_LOGIN", "Usuário ou senha inválidos.");
            return View("Index", model);
        }
    }
}