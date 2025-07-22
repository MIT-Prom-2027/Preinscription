using System;
using System.Collections.Generic;

namespace Preinscription.Models;

public partial class Faculte
{
    public int Id { get; set; }

    public string? NomFaculte { get; set; }

    public virtual ICollection<Mention> Mentions { get; set; } = new List<Mention>();
}
