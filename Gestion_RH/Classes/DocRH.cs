using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Gestion_RH.Classes;

namespace Gestion_RH.Classes
{
    public class DocRH
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomFichier { get; set; } = string.Empty;

        [Column(TypeName = "LONGBLOB")]
        [Required]
        public byte[] Fichier { get; set; } = Array.Empty<byte>();

        [ForeignKey("Employe")]
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }
    }
}
