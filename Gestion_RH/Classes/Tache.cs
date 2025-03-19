using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_RH.Classes
{
    public class Tache
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; } = string.Empty;
        public DateTime DateExpedition { get; set; }
        public DateTime? DateRendu { get; set; } // Peut être null si la tâche n'est pas encore rendue
        public DateTime Deadline { get; set; }
        public bool Statut { get; set; } = false; // True = terminée, False = en cours

        // Relations
        public ICollection<Support> Supports { get; set; } = new List<Support>();
        public ICollection<Consigne> Consignes { get; set; } = new List<Consigne>();
        public ICollection<EmployeTache> EmployeTaches { get; set; } = new List<EmployeTache>();
    }
}
