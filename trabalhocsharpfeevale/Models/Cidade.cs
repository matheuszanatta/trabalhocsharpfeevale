using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{   
    [Table("Cidades")]
    public class Cidade
    {
        public int IDCidade { get; set; }

        public string Nome { get; set; }
    }
}
