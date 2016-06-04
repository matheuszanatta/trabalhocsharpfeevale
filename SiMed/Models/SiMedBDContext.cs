using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SiMed.Models;

namespace SiMed.Models
{
    public class SiMedBDContext : DbContext
    {
        static SiMedBDContext()
        {
            //Database.SetInitializer<SiMedBDContext>(null);
            Database.SetInitializer<SiMedBDContext>(new CreateDatabaseIfNotExists<SiMedBDContext>());
        }
        public SiMedBDContext()
            : base("Name=SiMedBDContext")
        {
        }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
