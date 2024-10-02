using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prototipo2.Models;

public partial class CreditosDiario
{

    [Key]
    public int IdCredito { get; set; }

    public int? IdUsuario { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal CreditosAsignados { get; set; }

    public decimal? CreditosConsumidos { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
