using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class ContratPosteComplementaire
    {
        public int ContratId { get; set; }
        public Contrat? Contrat { get; set; }

        public int PosteId { get; set; }
        public Poste? Poste { get; set; }
    }

}
