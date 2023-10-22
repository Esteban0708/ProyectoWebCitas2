using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoWebCitas.Models;

public partial class ProyectoCitasContext : DbContext
{
    public ProyectoCitasContext()
    {
    }

    public ProyectoCitasContext(DbContextOptions<ProyectoCitasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisoRol> PermisoRols { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=ProyectoCitas;integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__GENERO__99A8E4F9E7DE1364");

            entity.ToTable("GENERO");

            entity.Property(e => e.IdGenero)
                .ValueGeneratedNever()
                .HasColumnName("id_genero");
            entity.Property(e => e.Genero1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("genero");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__PERMISO__228F224F4ADE04DF");

            entity.ToTable("PERMISO");

            entity.Property(e => e.IdPermiso)
                .ValueGeneratedNever()
                .HasColumnName("id_permiso");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PermisoRol>(entity =>
        {
            entity.HasKey(e => new { e.IdPermiso, e.IdRol }).HasName("PK__PERMISO___3424E9117E565DCF");

            entity.ToTable("PERMISO_ROL");

            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ROL");

            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Nuip).HasName("PK_nuip");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Nuip)
                .ValueGeneratedNever()
                .HasColumnName("nuip");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
