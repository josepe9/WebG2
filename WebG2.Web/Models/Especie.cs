﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebG2.Web.Models
{
    public class Especie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        public ICollection<Animal> Animales { get; set; }
    }
}
