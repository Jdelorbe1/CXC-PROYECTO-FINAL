using System;
using System.Collections.Generic;

namespace CXCPROYECTOFINAL.Models;

public partial class TipossDocumento
{
    public int Identificador { get; set; }

    public string? Descripcion { get; set; }

    public string? CuentaContable { get; set; }

    public string? Estado { get; set; }
}
