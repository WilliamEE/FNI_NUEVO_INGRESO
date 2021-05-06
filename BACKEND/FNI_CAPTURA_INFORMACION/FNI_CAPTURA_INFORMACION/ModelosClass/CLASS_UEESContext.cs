using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FNI_CAPTURA_INFORMACION.ModelosClass
{
    public partial class CLASS_UEESContext : DbContext
    {
        public CLASS_UEESContext()
        {
        }

        public CLASS_UEESContext(DbContextOptions<CLASS_UEESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NiCarrerasOfertada> NiCarrerasOfertadas { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.0.8;user=SA2;password=UEES.1234;database=CLASS_UEES");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<NiCarrerasOfertada>(entity =>
            {
                entity.HasKey(e => e.Correlativo);

                entity.ToTable("NI_CARRERAS_OFERTADAS");

                entity.Property(e => e.Correlativo).HasColumnName("CORRELATIVO");

                entity.Property(e => e.EstadoNi)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO_NI");

                entity.Property(e => e.Idcarrera)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IDCARRERA");
            });

            modelBuilder.Entity<Niveles>(entity =>
            {
                entity.HasKey(e => e.Nivcod);

                entity.ToTable("NIVELES");

                entity.HasIndex(e => new { e.Nivbnk, e.Nivcar, e.Nivsts, e.Nivdsc }, "_dta_index_NIVELES_7_2043154324__K21_K5_K11_K2_1");

                entity.HasIndex(e => new { e.Nivbnk, e.Nivcod, e.Nivtab }, "_dta_index_NIVELES_7_723741881__K21_K1_K15")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.Nivbnk, e.Nivcod }, "_dta_index_NIVELES_8_1534628510__K21_K1_2")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.Nivcod, e.Nivbnk }, "_dta_index_NIVELES_c_7_723741881__K1_K21")
                    .IsClustered()
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Nivabe)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVABE")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivape)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVAPE")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivbea)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVBEA");

                entity.Property(e => e.Nivbec)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVBEC")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivbef)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVBEF");

                entity.Property(e => e.Nivbem)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVBEM");

                entity.Property(e => e.Nivbnk)
                    .HasMaxLength(2)
                    .HasColumnName("NIVBNK");

                entity.Property(e => e.Nivcar)
                    .HasMaxLength(10)
                    .HasColumnName("NIVCAR");

                entity.Property(e => e.Nivccn)
                    .HasMaxLength(10)
                    .HasColumnName("NIVCCN");

                entity.Property(e => e.Nivccp)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCCP");

                entity.Property(e => e.Nivccv)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCCV");

                entity.Property(e => e.Nivccy)
                    .HasMaxLength(3)
                    .HasColumnName("NIVCCY");

                entity.Property(e => e.Nivcdc)
                    .HasMaxLength(35)
                    .HasColumnName("NIVCDC");

                entity.Property(e => e.Nivcdi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVCDI")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivcdm)
                    .HasMaxLength(35)
                    .HasColumnName("NIVCDM");

                entity.Property(e => e.Nivcla)
                    .HasMaxLength(10)
                    .HasColumnName("NIVCLA");

                entity.Property(e => e.Nivcne)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("NIVCNE");

                entity.Property(e => e.Nivcod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NIVCOD");

                entity.Property(e => e.Nivcpe)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCPE")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivcre)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("NIVCRE");

                entity.Property(e => e.Nivcsu)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCSU");

                entity.Property(e => e.Nivctc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCTC")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivctu)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCTU");

                entity.Property(e => e.Nivcxc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCXC")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivcxp)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVCXP")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivdcc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVDCC");

                entity.Property(e => e.Nivddc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVDDC");

                entity.Property(e => e.Nivdes)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVDES")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivdir)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVDIR")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivdoc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVDOC");

                entity.Property(e => e.Nivdsa)
                    .HasMaxLength(35)
                    .HasColumnName("NIVDSA");

                entity.Property(e => e.Nivdsc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NIVDSC");

                entity.Property(e => e.Nivdsm)
                    .HasMaxLength(35)
                    .HasColumnName("NIVDSM");

                entity.Property(e => e.Nivfac)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NIVFAC")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivfap)
                    .HasColumnType("datetime")
                    .HasColumnName("NIVFAP");

                entity.Property(e => e.Nivgln)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVGLN")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivgra)
                    .HasMaxLength(70)
                    .HasColumnName("NIVGRA");

                entity.Property(e => e.Nivimp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVIMP")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivins)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("NIVINS");

                entity.Property(e => e.Nivitu)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("NIVITU");

                entity.Property(e => e.Nivlet)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVLET")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivmat)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("NIVMAT");

                entity.Property(e => e.Nivmfn)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("NIVMFN");

                entity.Property(e => e.Nivmod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVMOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivmra).HasColumnName("NIVMRA");

                entity.Property(e => e.Nivmte)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("NIVMTE");

                entity.Property(e => e.Nivmtr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NIVMTR")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivnta)
                    .HasMaxLength(5)
                    .HasColumnName("NIVNTA");

                entity.Property(e => e.Nivntb)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("NIVNTB");

                entity.Property(e => e.Nivpcr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nivpcr")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivpen)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("NIVPEN");

                entity.Property(e => e.Nivrcx)
                    .HasColumnType("numeric(7, 4)")
                    .HasColumnName("NIVRCX");

                entity.Property(e => e.Nivsts)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVSTS")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivtab)
                    .HasMaxLength(10)
                    .HasColumnName("NIVTAB");

                entity.Property(e => e.Nivtcm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NIVTCM")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivtra)
                    .HasMaxLength(1)
                    .HasColumnName("NIVTRA")
                    .IsFixedLength(true);

                entity.Property(e => e.Nivuni)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NIVUNI");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
