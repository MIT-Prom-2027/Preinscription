using System;
using System.Collections.Generic;

namespace Preinscription.Models;

public partial class Preinscription
{
    public int NumBacc { get; set; }

    public int AnneeBacc { get; set; }

    public string? Email { get; set; }

    public string? Tel { get; set; }

    public string RecuBancaire { get; set; } = null!;

    public DateOnly? DatePreinscription { get; set; }

    public int? IdParcours { get; set; }

    public string? CheminPreuvePaiement { get; set; }

    public bool? EstValide { get; set; }

    public virtual Parcour? IdParcoursNavigation { get; set; }
}
