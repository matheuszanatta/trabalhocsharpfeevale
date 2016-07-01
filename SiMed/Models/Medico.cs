using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SiMed.Models
{
    public class Medico
    {
        public Medico()
        {

        }

        public Medico(MedicoCadastroModel medicoCadastro)
        {
            this.IDMedico = medicoCadastro.IDMedico;
            this.CRM = medicoCadastro.CRM;
            this.Nome = medicoCadastro.Nome;
            this.Endereco = medicoCadastro.Endereco;
            this.Bairro = medicoCadastro.Bairro;
            this.Email = medicoCadastro.Email;
            this.AtendePorConvenio = medicoCadastro.AtendePorConvenio;
            this.TemClinica = medicoCadastro.TemClinica;
            this.WebsiteBlog = medicoCadastro.WebsiteBlog;
            this.IDCidade = medicoCadastro.IDCidade;
            this.IDEspecialidade = medicoCadastro.IDEspecialidade;
    }

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
        public bool Ativo { get; set; }
        public long IDUsuario { get; set; }

        [ForeignKey("IDCidade")]
        public virtual Cidade Cidade { get; set; }

        [ForeignKey("IDEspecialidade")]
        public virtual Especialidade Especialidade { get; set; }

        [ForeignKey("IDMedico")]
        public IList<Agendamento> Agendamentos { get; set; }

        [ForeignKey("IDUsuario")]
        public Usuario Usuario { get; set; }
    }
}
