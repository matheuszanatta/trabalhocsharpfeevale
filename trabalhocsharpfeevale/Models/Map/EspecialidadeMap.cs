using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace trabalhocsharpfeevale.Models.Map
{
    public class EspecialidadeMap : EntityTypeConfiguration<Especialidade>
    {
        public EspecialidadeMap()
        {
            ToTable("Especialidades");

            HasKey(e => e.IDEspecialidade);

            Property(e => e.Nome).IsRequired().HasMaxLength(80);
        }
    }
}