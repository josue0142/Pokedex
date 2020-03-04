using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Region
    {
        public Region()
        {
            Pokemon = new HashSet<Pokemon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
