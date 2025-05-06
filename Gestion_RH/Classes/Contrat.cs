using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class Contrat
    {
        public int Id { get; set; }
        [ForeignKey("Employe")]
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        [ForeignKey("Poste")]
        public int PostePrincipalId { get; set; }
        public Poste? PostePrincipal { get; set; }

        public decimal SalaireDeBase { get; set; }

        // Relations N:M via classes de liaison
        public ICollection<ContratPosteComplementaire>? PostesComplementaires { get; set; }
        public ICollection<ContratPrime>? PrimesAcceptees { get; set; }
        public ICollection<ContratRetenue>? RetenuesAcceptees { get; set; }
    }


}
