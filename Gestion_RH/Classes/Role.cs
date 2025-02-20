using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gestion_RH.Classes
{
    public class Role
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nom { get; set; } = string.Empty;
    }
}
