using System;
using System.Collections.Generic;

namespace preinscription.Models;

public partial class Option1
{
    public int IdOption { get; set; }

    public string? Serie { get; set; }

    public virtual ICollection<Bachelier> Bacheliers { get; set; } = new List<Bachelier>();
}
