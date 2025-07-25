using System;
using System.Collections.Generic;

namespace preinscription.Models;

public partial class Mention1
{
    public int IdMention { get; set; }

    public string NomMention { get; set; } = null!;

    public int? Min { get; set; }

    public int? Max { get; set; }

    public virtual ICollection<Bachelier> Bacheliers { get; set; } = new List<Bachelier>();
}
