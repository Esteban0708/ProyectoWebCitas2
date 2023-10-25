using System;
using System.Collections.Generic;

namespace ProyectoWebCitas.Models;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string Nombre { get; set; } = null!;

    public int FkDepartamento { get; set; }

    public virtual Departamento FkDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
