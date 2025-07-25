﻿using System;
using System.Collections.Generic;

namespace preinscription.Models;

public partial class Province
{
    public int IdProvince { get; set; }

    public string NomProvince { get; set; } = null!;

    public virtual ICollection<Centre> Centres { get; set; } = new List<Centre>();
}
