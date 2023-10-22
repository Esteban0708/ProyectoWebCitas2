using System;
using System.Collections.Generic;

namespace ProyectoWebCitas.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;
}
