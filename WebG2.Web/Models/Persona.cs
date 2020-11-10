using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebG2.Web.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Documento { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }

        [StringLength(45)]
        public string Email { get; set; }

        [StringLength(45)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        public ICollection<Animal> Animales { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
