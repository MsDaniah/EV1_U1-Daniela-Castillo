using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EV1U1.Models;

public partial class MercyDevelopersContext : DbContext
{
    public MercyDevelopersContext()
    {
    }

    public MercyDevelopersContext(DbContextOptions<MercyDevelopersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Clientesservicio> Clientesservicios { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idclientes).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.Idclientes)
                .HasColumnType("int(11)")
                .HasColumnName("idclientes");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(45)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Rut)
                .HasMaxLength(45)
                .HasColumnName("rut");
            entity.Property(e => e.Telefono)
                .HasColumnType("int(11)")
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Clientesservicio>(entity =>
        {
            entity.HasKey(e => e.Idclientesservicios).HasName("PRIMARY");

            entity.ToTable("clientesservicios");

            entity.HasIndex(e => e.Idclientes, "idclientes_idx");

            entity.HasIndex(e => e.Idservicios, "idservicios_idx");

            entity.Property(e => e.Idclientesservicios)
                .HasColumnType("int(11)")
                .HasColumnName("idclientesservicios");
            entity.Property(e => e.Estado)
                .HasMaxLength(45)
                .HasColumnName("estado");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaTermino).HasColumnName("fecha_termino");
            entity.Property(e => e.Idclientes)
                .HasColumnType("int(11)")
                .HasColumnName("idclientes");
            entity.Property(e => e.Idservicios)
                .HasColumnType("int(11)")
                .HasColumnName("idservicios");

            entity.HasOne(d => d.IdclientesNavigation).WithMany(p => p.Clientesservicios)
                .HasForeignKey(d => d.Idclientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idclientes");

            entity.HasOne(d => d.IdserviciosNavigation).WithMany(p => p.Clientesservicios)
                .HasForeignKey(d => d.Idservicios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idservicios");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicios).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.Property(e => e.Idservicios)
                .HasColumnType("int(11)")
                .HasColumnName("idservicios");
            entity.Property(e => e.Duracion)
                .HasMaxLength(45)
                .HasColumnName("duracion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasColumnName("tipo");
            entity.Property(e => e.Valor)
                .HasColumnType("int(11)")
                .HasColumnName("valor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
