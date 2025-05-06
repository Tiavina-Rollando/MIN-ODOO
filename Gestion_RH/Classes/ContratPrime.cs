using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class ContratPrime
    {
        public int ContratId { get; set; }
        public Contrat? Contrat { get; set; }

        public int PrimeId { get; set; }
        public Prime? Prime { get; set; }
    }

}
