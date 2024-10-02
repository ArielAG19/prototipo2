using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prototipo2.Models;

public partial class Reserva
{
    [Key]
    public int IdReserva { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdMenu { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraReserva { get; set; }

    public int? IdTurno { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Turno? IdTurnoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
