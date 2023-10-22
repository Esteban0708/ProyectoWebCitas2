using System;
using System.Collections.Generic;

namespace ProyectoWebCitas.Models;

public partial class PermisoRol
{
    public int IdPermiso { get; set; }

    public int IdRol { get; set; }

    public string Estado { get; set; } = null!;
}
