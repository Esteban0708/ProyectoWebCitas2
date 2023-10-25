using System;
using System.Collections.Generic;

namespace ProyectoWebCitas.Models;

public partial class Documento
{
    public int IdDocumento { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
