using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using prototipo2.Models;

namespace prototipo2.Data
{
    public class prototipo2Context : DbContext
    {
        public prototipo2Context (DbContextOptions<prototipo2Context> options)
            : base(options)
        {
        }

        public DbSet<prototipo2.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<prototipo2.Models.Turno> Turno { get; set; } = default!;
        public DbSet<prototipo2.Models.TiposConsumo> TiposConsumo { get; set; } = default!;
        public DbSet<prototipo2.Models.Reserva> Reserva { get; set; } = default!;
        public DbSet<prototipo2.Models.Menu> Menu { get; set; } = default!;
        public DbSet<prototipo2.Models.CreditosDiario> CreditosDiario { get; set; } = default!;
        public DbSet<prototipo2.Models.Consumo> Consumo { get; set; } = default!;
    }
}
