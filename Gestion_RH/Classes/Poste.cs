﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gestion_RH.Classes
{
    public class Poste
    {
        [Key]
        public int Id { get; set; }

        public bool Statut { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nom { get; set; } = string.Empty;
        [ForeignKey("Departement")]
        public int IdDepartement { get; set; }
        public Departement? Departement { get; set; }
        public string NomDepartement => Departement?.Nom ?? string.Empty;
        public string StatutTexte => Statut ? "Occupé" : "Vaccant";
        public ICollection<Contrat> Contrats { get; set; } = new List<Contrat>();
    }
}