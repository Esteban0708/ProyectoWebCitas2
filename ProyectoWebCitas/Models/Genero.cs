﻿using System;
using System.Collections.Generic;

namespace ProyectoWebCitas.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string Genero1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
