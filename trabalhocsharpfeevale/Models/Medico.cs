using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhocsharpfeevale.Models
{   
    public class Medico
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

        public long IDCidade{ get; set; }

        public long IDEspecialidade { get; set; }

    }
}
