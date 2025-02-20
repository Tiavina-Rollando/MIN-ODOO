
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

        public DbSet<Employe> Employes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Poste> Postes { get; set; }

    }

}
