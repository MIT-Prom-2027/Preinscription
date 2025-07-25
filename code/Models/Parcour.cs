using System;
using System.Collections.Generic;

namespace preinscription.Models;

public partial class Parcour
{
    public int Id { get; set; }

    public int? IdMention { get; set; }

    public string? NomParcours { get; set; }

    public virtual Mention? IdMentionNavigation { get; set; }
}
