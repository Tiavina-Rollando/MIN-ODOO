using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class PrimesEmploye
    {
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }

        public int PrimeId { get; set; }
        public Prime? Prime { get; set; }
        public decimal Montant { get; set; }
        public string? Description { get; set; }
    }
}
