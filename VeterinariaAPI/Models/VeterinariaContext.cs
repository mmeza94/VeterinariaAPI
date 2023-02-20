using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VeterinariaAPI.Models
{
    public partial class VeterinariaContext : DbContext
    {
        public VeterinariaContext()
        {
        }

        public VeterinariaContext(DbContextOptions<VeterinariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Citas", "Veterinaria");

                entity.Property(e => e.CitaId)
                      .ValueGeneratedOnAdd()
                      .HasColumnName("CitaID");

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime").HasDefaultValue(DateTime.Now);

                entity.Property(e => e.NombreMascota)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Propietario)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Active).HasDefaultValue(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
