using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pokedex.Models
{
    public partial class DBPokedexContext : DbContext
    {
        public DBPokedexContext()
        {
        }

        public DBPokedexContext(DbContextOptions<DBPokedexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-646P9691\\SQLEXPRESS01;Database=DBPokedex;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.Property(e => e.Powers)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegionFk).HasColumnName("Region_Fk");

                entity.Property(e => e.TypeFk).HasColumnName("Type_Fk");

                entity.HasOne(d => d.RegionFkNavigation)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.RegionFk)
                    .HasConstraintName("FK_Pokemon_Region");

                entity.HasOne(d => d.TypeFkNavigation)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.TypeFk)
                    .HasConstraintName("FK_Pokemon_Type");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
