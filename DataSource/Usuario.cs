using System;
using System.Collections.Generic;

namespace DataSource;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte Edad { get; set; }
}
