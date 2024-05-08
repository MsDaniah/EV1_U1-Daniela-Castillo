using System;
using System.Collections.Generic;

namespace EV1U1.Models;

public partial class Clientesservicio
{
    public int Idclientesservicios { get; set; }

    public int Idclientes { get; set; }

    public int Idservicios { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaTermino { get; set; }

    public string? Estado { get; set; }

    public virtual Cliente IdclientesNavigation { get; set; } = null!;

    public virtual Servicio IdserviciosNavigation { get; set; } = null!;
}
