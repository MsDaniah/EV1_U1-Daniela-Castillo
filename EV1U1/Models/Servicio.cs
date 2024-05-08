using System;
using System.Collections.Generic;

namespace EV1U1.Models;

public partial class Servicio
{
    public int Idservicios { get; set; }

    public string? Tipo { get; set; }

    public string? Duracion { get; set; }

    public int? Valor { get; set; }

    public virtual ICollection<Clientesservicio> Clientesservicios { get; set; } = new List<Clientesservicio>();
}
