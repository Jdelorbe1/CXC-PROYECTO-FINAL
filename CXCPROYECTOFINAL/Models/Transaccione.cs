using System;
using System.Collections.Generic;

namespace CXCPROYECTOFINAL.Models;

public partial class Transaccione
{
    public int IdentificadorTransaccion { get; set; }

    public string? TipoMovimiento { get; set; }

    public int? IdentificadorTipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdentificadorCliente { get; set; }

    public decimal? Monto { get; set; }
}
