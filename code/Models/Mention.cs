using System;
using System.Collections.Generic;

namespace preinscription.Models;

public partial class Mention
{
    public int Id { get; set; }

    public int? IdFaculte { get; set; }

    public string? NomMention { get; set; }

    public virtual Faculte? IdFaculteNavigation { get; set; }

    public virtual ICollection<Parcour> Parcours { get; set; } = new List<Parcour>();
}
