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

    public int FkGenero { get; set; }

    public int FkDocumento { get; set; }

    public int FkCiudad { get; set; }

    public int FkRol { get; set; }

    public virtual Ciudad FkCiudadNavigation { get; set; } = null!;

    public virtual Documento FkDocumentoNavigation { get; set; } = null!;

    public virtual Genero FkGeneroNavigation { get; set; } = null!;

    public virtual Rol FkRolNavigation { get; set; } = null!;
}
