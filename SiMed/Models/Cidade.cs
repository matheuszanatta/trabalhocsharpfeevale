using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiMed.Models
{
    public class Cidade
    {
        public Cidade()
        {
            this.Medicos = new List<Medico>();
        }
        [Key]
        public int IDCidade { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }

    }
}
