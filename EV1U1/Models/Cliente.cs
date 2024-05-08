using System;
using System.Collections.Generic;

namespace EV1U1.Models;

public partial class Cliente
{
    public int Idclientes { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Rut { get; set; }

    public int? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Clientesservicio> Clientesservicios { get; set; } = new List<Clientesservicio>();
}
