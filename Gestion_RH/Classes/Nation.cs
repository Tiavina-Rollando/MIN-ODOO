using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gestion_RH.Classes
{
    public class Nation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Peuple { get; set; } = string.Empty;

        [Column(TypeName = "LONGBLOB")]
        public byte[] Drapeau { get; set; } = Array.Empty<byte>();

    }
}