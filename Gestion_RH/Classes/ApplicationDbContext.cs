
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

            // Configuration clé composée pour chaque classe de liaison
            modelBuilder.Entity<ContratPosteComplementaire>()
                .HasKey(cp => new { cp.ContratId, cp.PosteId });

            modelBuilder.Entity<ContratPrime>()
                .HasKey(cp => new { cp.ContratId, cp.PrimeId });

            modelBuilder.Entity<ContratRetenue>()
                .HasKey(cr => new { cr.ContratId, cr.RetenueId });

            modelBuilder.Entity<PrimesEmploye>()
                .HasKey(cr => new { cr.EmployeId, cr.PrimeId });

            modelBuilder.Entity<PrimesEmploye>()
                .HasOne(pe => pe.Employe)
                .WithMany(e => e.PrimesEmployes) // à définir dans la classe Employe
                .HasForeignKey(pe => pe.EmployeId);

            modelBuilder.Entity<PrimesEmploye>()
                .HasOne(pe => pe.Prime)
                .WithMany(p => p.PrimesEmployes) // à définir dans la classe Prime
                .HasForeignKey(pe => pe.PrimeId);

            modelBuilder.Entity<RetenuesEmploye>()
                .HasKey(cr => new { cr.EmployeId, cr.RetenueId });

            modelBuilder.Entity<RetenuesEmploye>()
                .HasOne(pe => pe.Employe)
                .WithMany(e => e.RetenuesEmployes) // à définir dans la classe Employe
                .HasForeignKey(pe => pe.EmployeId);

            modelBuilder.Entity<RetenuesEmploye>()
                .HasOne(pe => pe.Retenue)
                .WithMany(p => p.RetenuesEmployes) // à définir dans la classe Prime
                .HasForeignKey(pe => pe.RetenueId);

            modelBuilder.Entity<EmployeTache>()
                .HasKey(et => new { et.EmployeId, et.TacheId });

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
        public DbSet<Cv> Cvs { get; set; }
        public DbSet<DocRH> DocsRH { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Conge> Conges { get; set; }
        public DbSet<HeureSup> HeuresSup { get; set; }
        public DbSet<Retard> Retards { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Prime> Primes { get; set; }
        public DbSet<Retenue> Retenues { get; set; }
        public DbSet<ContratPosteComplementaire> ContratPostesComplementaires { get; set; }
        public DbSet<ContratPrime> ContratPrimes { get; set; }
        public DbSet<ContratRetenue> ContratRetenues { get; set; }
        public DbSet<Pointage> Pointages{ get; set; }
        public DbSet<PrimesEmploye> PrimesEmploye { get; set; }
        public DbSet<RetenuesEmploye> RetenuesEmploye { get; set; }
    }

}
