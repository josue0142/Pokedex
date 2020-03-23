using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public partial class Type
    {
        public Type()
        {
            Pokemon = new HashSet<Pokemon>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Upss.. Debes colocar un nombre" )]
        [Display(Name = "Nombre del Tipo")]
        public string Name { get; set; }
                
        public string color { get; set; }

        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
