using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiMed.Models
{
    public class Usuario
    {
        [Key]
        public long IDUsuario { get; set; }
        public string Nome { get; set; }

        [Required]
        [MinLength(1)]
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Permissao Permissao { get; set; }
    }

    public enum Permissao
    {
        USUARIO = 0, MEDICO = 1
    }
}
