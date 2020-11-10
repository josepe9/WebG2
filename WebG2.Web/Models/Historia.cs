using System;
using System.ComponentModel.DataAnnotations;

namespace WebG2.Web.Models
{
    public class Historia
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Animal")]
        public int AnimalId { get; set; }

        [Required]
        [Display(Name = "Enfermedad")]
        public int EnfermedadId { get; set; }

        [Required]
        [Display(Name = "Medico veterinario")]
        public int VeterinarioId { get; set; }

        public Animal Animal { get; set; }
        public Enfermedad Enfermedad { get; set; }
        public Veterinario Veterinario { get; set; }

    }
}
