using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Gestion_RH.Classes;

namespace Gestion_RH.Classes
{
    public class Support
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomFichier { get; set; } = string.Empty;

        [Column(TypeName = "LONGBLOB")]
        [Required]
        public byte[] Fichier { get; set; } = Array.Empty<byte>();

        [ForeignKey("Tache")]
        public int TacheId { get; set; }
        public Tache? Tache { get; set; }
    }
}
