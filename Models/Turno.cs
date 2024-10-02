using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prototipo2.Models;

public partial class Turno
{
    [Key]
    public int IdTurno { get; set; }

    public int? IdTipoConsumo { get; set; }

    public string? Turno1 { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<Consumo> Consumos { get; set; } = new List<Consumo>();

    public virtual TiposConsumo? IdTipoConsumoNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
