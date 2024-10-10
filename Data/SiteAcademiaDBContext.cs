using Microsoft.EntityFrameworkCore;
using SiteAcademia.Data.Map;
using SiteAcademia.Models;

namespace SiteAcademia.Data
{
    public class SiteAcademiaDBContext: DbContext
    {
        public SiteAcademiaDBContext(DbContextOptions<SiteAcademiaDBContext> options)
            : base(options) 
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PersonalModel>Personais { get; set; }
        public DbSet<TreinoModel> Treinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PersonalMap());
            modelBuilder.ApplyConfiguration(new TreinoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
