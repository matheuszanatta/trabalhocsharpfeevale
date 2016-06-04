using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiMed.Models
{
    public class Pessoa
    {   
        [Key]
        public string CPF { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}