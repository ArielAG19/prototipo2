using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prototipo2.Models;

public partial class Consumo
{
    [Key]
    public int IdConsumo { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdMenu { get; set; }

    public DateOnly FechaConsumo { get; set; }

    public TimeOnly HoraConsumo { get; set; }

    public int? IdTurno { get; set; }

    public string? EmpleadoEntrega { get; set; }

    public decimal? MontoPagado { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Turno? IdTurnoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
