using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace trabalhocsharpfeevale.Models.Map
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoas");

            HasKey(p => p.CPF);

            Property(p => p.Nome).IsRequired().HasMaxLength(50);
            Property(p => p.Idade).IsRequired();
        }
    }
}