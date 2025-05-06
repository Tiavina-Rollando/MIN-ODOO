using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Gestion_RH.Classes;

namespace Gestion_RH.Classes
{
    public class HeureSup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Quantite { get; set; }
        public DateTime Date{ get; set; }

        [ForeignKey("Employe")]
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }
    }
}
