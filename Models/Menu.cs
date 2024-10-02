using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prototipo2.Models;

public partial class Menu
{
    [Key]
    public int IdMenu { get; set; }

    public int? IdTipoConsumo { get; set; }

    public string? NombreMenu { get; set; }

    public string? Descripcion { get; set; }

    public decimal? CostoExtra { get; set; }

    public int? CantidadDisponible { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual ICollection<Consumo> Consumos { get; set; } = new List<Consumo>();

    public virtual TiposConsumo? IdTipoConsumoNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
