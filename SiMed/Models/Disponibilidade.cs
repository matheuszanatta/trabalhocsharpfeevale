using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiMed.Models
{
    public class Disponibilidade
    {   
        [Key]
        public long IDDisponibilidade { get; set; }

        public long IDMedico { get; set; }
        public DateTime Dia { get; set; }
        public TimeSpan InicioTurno1 { get; set; }
        public TimeSpan FimTurno1 { get; set; }
        public TimeSpan InicioTurno2 { get; set; }
        public TimeSpan FimTurno2 { get; set; }

        [ForeignKey("IDMedico")]
        public Medico Medico { get; set; }
    }
}