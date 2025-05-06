using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Gestion_RH.Classes;

namespace Gestion_RH.Classes
{
    public class Retenue
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Motif { get; set; } = string.Empty;
        public decimal Taux { get; set; }
        public ICollection<RetenuesEmploye>? RetenuesEmployes { get; set; }

    }
}
