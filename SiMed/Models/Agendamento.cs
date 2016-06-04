using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiMed.Models
{
    [Table("Agendamentos")]
    public class Agendamento
    {   
        [Key]
        public int IdAgendamento { get; set; }

        public long IDMedico { get; set; }
        public string CPFPessoa { get; set; }
        public DateTime DhAgendamento { get; set; }
        public bool Situacao { get; set; }
        public Classificacao Classificacao { get; set; }

        [ForeignKey("IDMedico")]
        public Medico Medico { get; set; }

        [ForeignKey("CPFPessoa")]
        public Pessoa Pessoa { get; set; }
    }

    public enum Classificacao
    {
        CONSULTA = 1, RECONSULTA = 2, CONSULTA_DE_ROTINA = 3
    }
}