using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace trabalhocsharpfeevale.Models.Map
{
    public class MedicoMap : EntityTypeConfiguration<Medico>
    {
        public MedicoMap()
        {
            ToTable("Medicos");

            HasKey(m => m.IDMedico);

            Property(m => m.CRM).IsRequired().HasMaxLength(30);
            Property(m => m.Nome).IsRequired().HasMaxLength(80);
            Property(m => m.Endereco).IsRequired().HasMaxLength(100);
            Property(m => m.Bairro).IsRequired().HasMaxLength(60);
            Property(m => m.Email).HasMaxLength(100);
            Property(m => m.AtendePorConvenio).IsRequired();
            Property(m => m.TemClinica).IsRequired();
            Property(m => m.WebsiteBlog).HasMaxLength(80);
        }
    }
}