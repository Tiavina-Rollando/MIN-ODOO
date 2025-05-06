using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class ContratRetenue
    {
        public int ContratId { get; set; }
        public Contrat? Contrat { get; set; }

        public int RetenueId { get; set; }
        public Retenue? Retenue { get; set; }
    }

}
