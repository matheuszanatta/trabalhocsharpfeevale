using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{   
    [Table("Especialidades")]
    public class Especialidade
    {
        public int IDEspecialidade { get; set; }

        public string Nome { get; set; }

    }
}
