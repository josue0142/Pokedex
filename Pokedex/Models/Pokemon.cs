using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public partial class Pokemon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Upss.. Debes colocar un nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Upss.. Debes seleccionar un tipo")]
        [Display(Name = "Tipo")]
        public int? TypeFk { get; set; }

        [Required(ErrorMessage = "Upss.. Debes seleccionar una region")]
        [Display(Name = "Region")]
        public int? RegionFk { get; set; }

        [Required(ErrorMessage = "Upss.. Debes colocar al menos un poder")]
        [Display(Name = "Poderes")]
        public string Powers { get; set; }

        public virtual Region RegionFkNavigation { get; set; }
        public virtual Type TypeFkNavigation { get; set; }
    }
}
