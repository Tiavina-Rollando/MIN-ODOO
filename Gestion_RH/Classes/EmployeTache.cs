using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class EmployeTache
    {
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }

        public int TacheId { get; set; }
        public Tache? Tache { get; set; }
    }


}
