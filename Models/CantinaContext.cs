using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace prototipo2.Models;

public partial class CantinaContext : DbContext
{
    public CantinaContext()
    {
    }

    public CantinaContext(DbContextOptions<CantinaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consumo> Consumos { get; set; }

    public virtual DbSet<CreditosDiario> CreditosDiarios { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<TiposConsumo> TiposConsumos { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseMySql("server=localhost;port=3306;database=cantina;uid=root;password=aagdbkaidem19", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Consumo>(entity =>
        {
            entity.HasKey(e => e.IdConsumo).HasName("PRIMARY");

            entity.ToTable("consumos");

            entity.HasIndex(e => e.IdMenu, "id_menu");

            entity.HasIndex(e => e.IdTurno, "id_turno");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdConsumo).HasColumnName("id_consumo");
            entity.Property(e => e.EmpleadoEntrega)
                .HasMaxLength(100)
                .HasColumnName("empleado_entrega");
            entity.Property(e => e.FechaConsumo).HasColumnName("fecha_consumo");
            entity.Property(e => e.HoraConsumo)
                .HasColumnType("time")
                .HasColumnName("hora_consumo");
            entity.Property(e => e.IdMenu).HasColumnName("id_menu");
            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.MontoPagado)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("monto_pagado");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Consumos)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("consumos_ibfk_2");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Consumos)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("consumos_ibfk_3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Consumos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("consumos_ibfk_1");
        });

        modelBuilder.Entity<CreditosDiario>(entity =>
        {
            entity.HasKey(e => e.IdCredito).HasName("PRIMARY");

            entity.ToTable("creditos_diarios");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdCredito).HasColumnName("id_credito");
            entity.Property(e => e.CreditosAsignados)
                .HasPrecision(5, 2)
                .HasColumnName("creditos_asignados");
            entity.Property(e => e.CreditosConsumidos)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("creditos_consumidos");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CreditosDiarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("creditos_diarios_ibfk_1");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PRIMARY");

            entity.ToTable("menus");

            entity.HasIndex(e => e.IdTipoConsumo, "id_tipo_consumo");

            entity.Property(e => e.IdMenu).HasColumnName("id_menu");
            entity.Property(e => e.CantidadDisponible).HasColumnName("cantidad_disponible");
            entity.Property(e => e.CostoExtra)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("costo_extra");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdTipoConsumo).HasColumnName("id_tipo_consumo");
            entity.Property(e => e.NombreMenu)
                .HasMaxLength(100)
                .HasColumnName("nombre_menu");

            entity.HasOne(d => d.IdTipoConsumoNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdTipoConsumo)
                .HasConstraintName("menus_ibfk_1");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PRIMARY");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.IdMenu, "id_menu");

            entity.HasIndex(e => e.IdTurno, "id_turno");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.HoraReserva)
                .HasColumnType("time")
                .HasColumnName("hora_reserva");
            entity.Property(e => e.IdMenu).HasColumnName("id_menu");
            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("reservas_ibfk_2");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("reservas_ibfk_3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("reservas_ibfk_1");
        });

        modelBuilder.Entity<TiposConsumo>(entity =>
        {
            entity.HasKey(e => e.IdTipoConsumo).HasName("PRIMARY");

            entity.ToTable("tipos_consumo");

            entity.Property(e => e.IdTipoConsumo).HasColumnName("id_tipo_consumo");
            entity.Property(e => e.CreditosNecesarios)
                .HasPrecision(5, 2)
                .HasColumnName("creditos_necesarios");
            entity.Property(e => e.HoraFin)
                .HasColumnType("time")
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.RequiereReserva)
                .HasDefaultValueSql("'0'")
                .HasColumnName("requiere_reserva");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PRIMARY");

            entity.ToTable("turnos");

            entity.HasIndex(e => e.IdTipoConsumo, "id_tipo_consumo");

            entity.Property(e => e.IdTurno).HasColumnName("id_turno");
            entity.Property(e => e.HoraFin)
                .HasColumnType("time")
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.IdTipoConsumo).HasColumnName("id_tipo_consumo");
            entity.Property(e => e.Turno1)
                .HasMaxLength(50)
                .HasColumnName("turno");

            entity.HasOne(d => d.IdTipoConsumoNavigation).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.IdTipoConsumo)
                .HasConstraintName("turnos_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Puesto)
                .HasMaxLength(100)
                .HasColumnName("puesto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
