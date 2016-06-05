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
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public Situacao Situacao { get; set; }
        public Classificacao Classificacao { get; set; }

        [ForeignKey("IDMedico")]
        public Medico Medico { get; set; }

        [ForeignKey("CPFPessoa")]
        public Pessoa Pessoa { get; set; }

        public TimeSpan TempoDeConsulta()
        {
            return this.Classificacao == Classificacao.CONSULTA ? new TimeSpan(1, 0, 0) : new TimeSpan(0, 30, 0);
        }

        public TimeSpan HoraFimDaConsulta()
        {
            return this.Hora.Add(this.TempoDeConsulta());
        }
    }

    public enum Classificacao
    {
        CONSULTA = 0, RECONSULTA = 1, CONSULTA_DE_ROTINA = 2
    }

    public enum Situacao
    {
        ATIVO = 1, INATIVO = 0
    }
}