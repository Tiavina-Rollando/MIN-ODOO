
namespace Gestion_RH.Classes
{
    using Microsoft.EntityFrameworkCore;
    using Pomelo.EntityFrameworkCore.MySql;
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Récupère la chaîne de connexion depuis App.config
            var connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["MySqlConnection"]?.ConnectionString;

            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            else
            {
                throw new InvalidOperationException("La chaîne de connexion 'MySqlConnection' n'a pas été trouvée.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Définition de la clé primaire composite pour EmployeTache
            modelBuilder.Entity<EmployeTache>()
                .HasKey(et => new { et.EmployeId, et.TacheId });

            // Définition des relations
            modelBuilder.Entity<EmployeTache>()
                .HasOne(et => et.Employe)
                .WithMany(e => e.EmployeTaches)
                .HasForeignKey(et => et.EmployeId);

            modelBuilder.Entity<EmployeTache>()
                .HasOne(et => et.Tache)
                .WithMany(t => t.EmployeTaches)
                .HasForeignKey(et => et.TacheId);
        }


        public DbSet<Employe> Employes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Poste> Postes { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Consigne> Consignes { get; set; }
        public DbSet<EmployeTache> EmployeTaches { get; set; }


    }

}
