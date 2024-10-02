using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prototipo2.Models;

public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Puesto { get; set; }

    public virtual ICollection<Consumo> Consumos { get; set; } = new List<Consumo>();

    public virtual ICollection<CreditosDiario> CreditosDiarios { get; set; } = new List<CreditosDiario>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
