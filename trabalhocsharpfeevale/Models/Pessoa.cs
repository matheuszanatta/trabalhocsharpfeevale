using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhocsharpfeevale.Models
{   
    public class Pessoa
    {
        public string CPF { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}
