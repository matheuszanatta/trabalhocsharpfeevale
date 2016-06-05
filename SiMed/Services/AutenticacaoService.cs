using SiMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiMed.Services
{
    public class AutenticacaoService
    {
        private SiMedBDContext db = new SiMedBDContext();
        private CriptografiaService criptografia = new CriptografiaService();

        public Usuario BuscarPorAutenticacao(string login, string senha)
        {
            Usuario usuario = db.Usuarios.FirstOrDefault(u => u.Login.Equals(login));

            if (usuario != null)
            {
                string senhaCriptografada = criptografia.CriptografarSenha(senha);

                if (usuario.Senha.ToUpper() != senhaCriptografada.ToUpper())
                {
                    return null;
                }
            }

            return usuario;
        }
    }
}