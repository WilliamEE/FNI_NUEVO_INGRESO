using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FNI_CAPTURA_INFORMACION.Modelos
{
    public partial class SUEESContext : DbContext
    {
        public SUEESContext()
        {
        }

        public SUEESContext(DbContextOptions<SUEESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FniSolicitudInicial> FniSolicitudInicials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.0.8;user=SA2;password=UEES.1234;database=SUEES");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<FniSolicitudInicial>(entity =>
            {
                entity.HasKey(e => e.Correlativo);

                entity.ToTable("FNI_SOLICITUD_INICIAL");

                entity.Property(e => e.Correlativo).HasColumnName("CORRELATIVO");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.CarreraInteres)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CARRERA_INTERES");

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FechaNac)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_NAC");

                entity.Property(e => e.Idformulario)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IDFORMULARIO");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
