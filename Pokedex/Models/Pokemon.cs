using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Pokemon
    {
        public int Id { get; set; }
        public int? TypeFk { get; set; }
        public int? RegionFk { get; set; }
        public string Powers { get; set; }

        public virtual Region RegionFkNavigation { get; set; }
        public virtual Type TypeFkNavigation { get; set; }
    }
}
