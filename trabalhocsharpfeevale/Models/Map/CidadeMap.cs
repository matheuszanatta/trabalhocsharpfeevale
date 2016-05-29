using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace trabalhocsharpfeevale.Models.Map
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidades");

            HasKey(c => c.IDCidade);

            Property(c => c.Nome).IsRequired().HasMaxLength(100);
        }
    }
}