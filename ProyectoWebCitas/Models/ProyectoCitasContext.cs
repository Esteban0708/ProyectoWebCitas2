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

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

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
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("CIUDAD");

            entity.Property(e => e.IdCiudad)
                .ValueGeneratedNever()
                .HasColumnName("id_ciudad");
            entity.Property(e => e.FkDepartamento).HasColumnName("FK_Departamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.FkDepartamentoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.FkDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DEPARTAMENTO");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK_DEPATAMENTO");

            entity.ToTable("DEPARTAMENTO");

            entity.Property(e => e.IdDepartamento)
                .ValueGeneratedNever()
                .HasColumnName("id_departamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDocumento).HasName("PK_Documento");

            entity.ToTable("DOCUMENTO");

            entity.Property(e => e.IdDocumento)
                .ValueGeneratedNever()
                .HasColumnName("id_documento");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK_Genero");

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
            entity.HasKey(e => e.IdPermiso).HasName("PK_permiso");

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
            entity.HasKey(e => new { e.IdPermiso, e.IdRol }).HasName("PK_PermisoRol");

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
            entity.HasKey(e => e.IdRol);

            entity.ToTable("ROL");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
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
            entity.Property(e => e.FkCiudad).HasColumnName("FK_Ciudad");
            entity.Property(e => e.FkDocumento).HasColumnName("Fk_Documento");
            entity.Property(e => e.FkGenero).HasColumnName("Fk_genero");
            entity.Property(e => e.FkRol).HasColumnName("FK_rol");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.FkCiudadNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CIUDAD");

            entity.HasOne(d => d.FkDocumentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento");

            entity.HasOne(d => d.FkGeneroNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GENERO");

            entity.HasOne(d => d.FkRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.FkRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
