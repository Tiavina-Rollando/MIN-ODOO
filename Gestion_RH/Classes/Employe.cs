using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Org.BouncyCastle.Asn1.Cmp;


namespace Gestion_RH.Classes
{

    public class Employe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Prenom { get; set; } = string.Empty;

        public DateTime? DateNaissance { get; set; }

        [Required]
        [MaxLength(255)]
        public string Adresse { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Matricule { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Mdp { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Tel { get; set; } = string.Empty;
        
        [Column(TypeName = "LONGBLOB")]
        public byte[] Empreinte { get; set; } = Array.Empty<byte>();

        [Column(TypeName = "LONGBLOB")]
        public byte[] Photo { get; set; } = Array.Empty<byte>();

        public bool Sexe { get; set; }

        public DateTime? DateIntegration { get; set; }

        [ForeignKey("Nation")]
        public int IdNation { get; set; }

        [ForeignKey("Role")]
        public int IdRole { get; set; }

        [ForeignKey("Poste")]
        public int IdPoste { get; set; }

        public Poste? Poste { get; set; }
        public Nation? Nation { get; set; }
        public Role? Role { get; set; }

        public string NomPoste => Poste?.Nom ?? string.Empty;
        public string NomDepartement => Poste?.Departement?.Nom ?? string.Empty;
        public string Genre => Sexe ? "Homme" : "Femme"; 
    }
}