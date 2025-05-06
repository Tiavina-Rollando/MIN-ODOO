using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Gestion_RH.Classes;

namespace Gestion_RH.Classes
{
    public class Conge
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Motif { get; set; } = string.Empty;
        public DateTime? Debut { get; set; }
        public DateTime? Fin { get; set; }

        [ForeignKey("Employe")]
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }
    }
}
