using System;
using System.Collections.Generic;

namespace ProyectoWebCitas.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;
}
