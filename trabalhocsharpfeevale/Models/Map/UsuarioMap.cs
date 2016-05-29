using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace trabalhocsharpfeevale.Models.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuarios");

            HasKey(u => u.IDUsuario);

            Property(u => u.Nome).IsRequired().HasMaxLength(80);
            Property(u => u.Login).IsRequired().HasMaxLength(30);
            Property(u => u.Senha).IsRequired().HasMaxLength(100);
            Property(u => u.Email).IsRequired().HasMaxLength(100);
        }
    }
}