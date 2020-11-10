using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebG2.Web.Models
{
    public class Veterinario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Persona")]
        public int PersonaId { get; set; }

        [StringLength(45)]
        public string Detalle { get; set; }

        public ICollection<Historia> Historias { get; set; }

    }
}
