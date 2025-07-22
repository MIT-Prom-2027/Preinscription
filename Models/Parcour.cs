using System;
using System.Collections.Generic;

namespace Preinscription.Models;

public partial class Parcour
{
    public int Id { get; set; }

    public int? IdMention { get; set; }

    public string? NomParcours { get; set; }

    public virtual Mention? IdMentionNavigation { get; set; }

    public virtual ICollection<Preinscription> Preinscriptions { get; set; } = new List<Preinscription>();
}
