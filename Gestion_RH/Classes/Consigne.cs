using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gestion_RH.Classes
{
    public class Consigne
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Designation { get; set; } = string.Empty; // Assure que Designation n'est pas null


        [ForeignKey("Tache")]
        public int TacheId { get; set; }
        public Tache Tache { get; set; }
    }
}
