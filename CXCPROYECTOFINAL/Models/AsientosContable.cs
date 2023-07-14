using System;
using System.Collections.Generic;

namespace CXCPROYECTOFINAL.Models;

public partial class AsientosContable
{
    public int IdentificadorAsiento { get; set; }

    public string? Descripcion { get; set; }

    public int? IdentificadorCliente { get; set; }

    public string? Cuenta { get; set; }

    public string? TipoMovimiento { get; set; }

    public int? IdentificadorTipoDocumento { get; set; }

    public DateTime? FechaAsiento { get; set; }

    public decimal? MontoAsiento { get; set; }

    public string? Estado { get; set; }
}
