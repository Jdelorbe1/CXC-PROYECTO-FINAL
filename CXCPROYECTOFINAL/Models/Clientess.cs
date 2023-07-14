using System;
using System.Collections.Generic;

namespace CXCPROYECTOFINAL.Models;

public partial class Clientess
{
    public int IdentificadorClientess { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public decimal? LimiteCredito { get; set; }

    public string? Estado { get; set; }
}
