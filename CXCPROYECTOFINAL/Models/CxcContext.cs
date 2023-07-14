using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CXCPROYECTOFINAL.Models;

public partial class CxcContext : DbContext
{
    public CxcContext()
    {
    }

    public CxcContext(DbContextOptions<CxcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsientosContable> AsientosContables { get; set; }

    public virtual DbSet<Clientess> Clientesses { get; set; }

    public virtual DbSet<TipossDocumento> TipossDocumentos { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=CXC; integrated security=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsientosContable>(entity =>
        {
            entity.HasKey(e => e.IdentificadorAsiento).HasName("PK__Asientos__0B8E4B92BB20A45C");

            entity.Property(e => e.IdentificadorAsiento).ValueGeneratedNever();
            entity.Property(e => e.Cuenta).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaAsiento).HasColumnType("date");
            entity.Property(e => e.MontoAsiento).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoMovimiento).HasMaxLength(2);
        });

        modelBuilder.Entity<Clientess>(entity =>
        {
            entity.HasKey(e => e.IdentificadorClientess).HasName("PK__Clientes__F9833F865B712578");

            entity.ToTable("Clientess");

            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.LimiteCredito).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<TipossDocumento>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK__TipossDo__F2374EB192B92A3D");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
            entity.Property(e => e.CuentaContable).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Estado).HasMaxLength(20);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.IdentificadorTransaccion).HasName("PK__Transacc__B6B41BD22C7B9AD5");

            entity.Property(e => e.IdentificadorTransaccion).ValueGeneratedNever();
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NumeroDocumento).HasMaxLength(50);
            entity.Property(e => e.TipoMovimiento).HasMaxLength(2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
