using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Medico
    {
        public int IDMedico { get; set; }

        public int CRM { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Email { get; set; }

        public bool AtendePorConvenio { get; set; }

        public bool TemClinica { get; set; }

        public string WebsiteBlog { get; set; }

    }
}
