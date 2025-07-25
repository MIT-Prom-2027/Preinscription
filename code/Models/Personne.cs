﻿using System;
using System.Collections.Generic;

namespace preinscription.Models;

public partial class Personne
{
    public int IdPersonne { get; set; }

    public string NomPrenom { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    public string LieuNaissance { get; set; } = null!;

    public string? Sexe { get; set; }

    public virtual ICollection<Bachelier> Bacheliers { get; set; } = new List<Bachelier>();
}
