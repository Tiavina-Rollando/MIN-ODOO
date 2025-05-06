using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class RetenuesEmploye
    {
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }

        public int RetenueId { get; set; }
        public Retenue? Retenue { get; set; }
        public decimal Montant { get; set; }
        public string? Description { get; set; }
    }
}
