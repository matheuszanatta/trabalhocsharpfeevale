using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SiMed.Models
{
    public class Medico
    {
        [Key]
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

        [ForeignKey("IDCidade")]
        public virtual Cidade Cidade { get; set; }

        [ForeignKey("IDEspecialidade")]
        public virtual Especialidade Especialidade { get; set; }
    }
}
