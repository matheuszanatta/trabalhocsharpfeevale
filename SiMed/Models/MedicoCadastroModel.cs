using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiMed.Models
{
    public class MedicoCadastroModel
    {
        public long IDMedico { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        public bool AtendePorConvenio { get; set; }
        public bool TemClinica { get; set; }
        public string WebsiteBlog { get; set; }
        public int IDCidade { get; set; }
        public int IDEspecialidade { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}