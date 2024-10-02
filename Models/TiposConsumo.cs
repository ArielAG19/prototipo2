using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prototipo2.Models;

public partial class TiposConsumo
{
    [Key]
    public int IdTipoConsumo { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal CreditosNecesarios { get; set; }

    public bool? RequiereReserva { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
