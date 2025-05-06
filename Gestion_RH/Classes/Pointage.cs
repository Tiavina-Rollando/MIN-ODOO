using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_RH.Classes
{
    public class Pointage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employe")]
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }
        public DateTime DateHeure { get; set; }
        public string? TypePointage { get; set; } // "Arrivée" ou "Départ"
        public string? Statut { get; set; } // "Normal", "Retard", "Absence"
    }
}
