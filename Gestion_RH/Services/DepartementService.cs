using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_RH.Classes;

namespace Gestion_RH.Services
{
    public class DepartementService
    {
        private readonly ApplicationDbContext _context;

        public DepartementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Departement> GetAllDepartement()
        {
            return _context.Departements.ToList();
        }

        public void AjouterDepartement(Departement departement)
        {
            _context.Departements.Add(departement);
            _context.SaveChanges();
        }

        public void SupprimerDepartement(long id)
        {
            var departement = _context.Departements.Find(id);
            if (departement != null)
            {
                _context.Departements.Remove(departement);
                _context.SaveChanges();
            }
        }
    }
}