using System;
using System.Collections.Generic;

namespace ProyectoWebCitas.Models;

public partial class Usuario
{
    public long Nuip { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Estado { get; set; } = null!;
}
