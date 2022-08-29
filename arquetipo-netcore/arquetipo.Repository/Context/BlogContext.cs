using arquetipo.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;



namespace arquetipo.Repository.Context
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public virtual DbSet<Post> Post { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Ejecutivo> Ejecutivos { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Patio> Patios { get; set; } = null!;
        public virtual DbSet<Solicitud> Solicituds { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CreditoVehicularBancoPichincha;Trusted_Connection=false;User ID=sa;Password=desarrollo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificacionConyuge)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NombreConyuge)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SujetoCredito)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAsignacion).HasColumnType("date");

                //entity.HasOne(d => d.Patio)
                //    .WithMany(p => p.Clientes)
                //    .HasForeignKey(d => d.PatioId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Cliente_Patio");
            });

            modelBuilder.Entity<Ejecutivo>(entity =>
            {
                entity.ToTable("Ejecutivo");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoConvencional)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Patio)
                //    .WithMany(p => p.Ejecutivos)
                //    .HasForeignKey(d => d.PatioId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Ejecutivo_Ejecutivo");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patio>(entity =>
            {
                entity.ToTable("Patio");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.ToTable("Solicitud");

                entity.Property(e => e.Entrada).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FechaElaboracion).HasColumnType("date");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Cliente)
                //    .WithMany(p => p.Solicituds)
                //    .HasForeignKey(d => d.ClienteId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Solicitud_Solicitud");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.Avaluo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cilindraje)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroChasis)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Marca)
                //    .WithMany(p => p.Vehiculos)
                //    .HasForeignKey(d => d.MarcaId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Vehiculo_Marca");

                //entity.HasOne(d => d.Patio)
                //    .WithMany(p => p.Vehiculos)
                //    .HasForeignKey(d => d.PatioId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Vehiculo_Patio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
