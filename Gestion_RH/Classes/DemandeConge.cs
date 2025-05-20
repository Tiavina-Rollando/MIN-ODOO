using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Classes
{
    public class DemandeConge
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Motif { get; set; } = string.Empty;
        public DateTime? Envoye { get; set; }
        public DateTime? Debut { get; set; }
        public DateTime? Fin { get; set; }
        public StatutDemandeConge Statut { get; set; }
        public Conge? Conge { get; set; }

        [ForeignKey("Employe")]
        public int EmployeId { get; set; }
        public Employe? Employe { get; set; }
        public string NomEmploye => Employe?.Nom + " " + Employe?.Prenom ?? string.Empty;
        public string StatutImage
        {
            get
            {
                return Statut switch
                {
                    StatutDemandeConge.Nouveau => "../Assets/notification.png",
                    StatutDemandeConge.EnAttente => "../Assets/en-cours.png",
                    StatutDemandeConge.Approuve => "../Assets/coche-verte.png",
                    StatutDemandeConge.Refuse => "../Assets/refuser.png",
                    StatutDemandeConge.Annule => "../Assets/annule.png"
                };
            }
        }
        public string TextStatut
        {
            get
            {
                return Statut switch
                {
                    StatutDemandeConge.Nouveau => "Nouvelle",
                    StatutDemandeConge.EnAttente => "En attente",
                    StatutDemandeConge.Approuve => "Approuvée",
                    StatutDemandeConge.Refuse => "Réfusée",
                    StatutDemandeConge.Annule => "Annulée"
                };
            }
        }
    }
}
