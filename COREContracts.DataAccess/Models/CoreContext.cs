using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COREContracts.DataAccess.Models
{
    public partial class CoreContext : DbContext
    {
        public CoreContext()
        {
        }

        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoreCarrier> CoreCarriers { get; set; }
        public virtual DbSet<CoreContract> CoreContracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CoreCarrier>(entity =>
            {
                entity.HasKey(e => e.CarrierId)
                    .HasName("PK__CORE_Carrier");

                entity.ToTable("CORE_Carrier");

                entity.Property(e => e.CarrierName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<CoreContract>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PK__CORE_Contract");

                entity.ToTable("CORE_Contract");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.TermDate).HasColumnType("date");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.CoreContracts)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CORE_Contract_CarrierId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
