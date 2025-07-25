using System;
using System.Collections.Generic;

namespace preinscription.Models;

public partial class Note
{
    public int IdNote { get; set; }

    public double ValeurNote { get; set; }

    public bool? EstOptionnel { get; set; }

    public int? IdMatiere { get; set; }

    public int? IdBachelier { get; set; }

    public virtual Bachelier? IdBachelierNavigation { get; set; }

    public virtual Matiere? IdMatiereNavigation { get; set; }
}
