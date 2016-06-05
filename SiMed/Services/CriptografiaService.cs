using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SiMed.Services
{
    public class CriptografiaService
    {
        public string CriptografarSenha(string senha)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(senha);

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            return BitConverter.ToString(sha1.ComputeHash(bytes)).Replace("-", "");
        }
    }
}