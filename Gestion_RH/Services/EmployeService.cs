using System.Collections.Generic;
using System.Linq;
using Gestion_RH.Classes;


namespace Gestion_RH.Services
{
    public class EmployeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Employe> GetAllEmployes()
        {
            return _context.Employes.ToList();
        }

        public void AjouterEmploye(Employe employe)
        {
            _context.Employes.Add(employe);
            _context.SaveChanges();
        }

        public void SupprimerEmploye(long id)
        {
            var employe = _context.Employes.Find(id);
            if (employe != null)
            {
                _context.Employes.Remove(employe);
                _context.SaveChanges();
            }
        }
    }
}