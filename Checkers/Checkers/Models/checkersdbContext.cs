using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace Checkers.Models
{
    public partial class checkersdbContext : DbContext
    {
        

        public checkersdbContext()
        {
        }

        public checkersdbContext(DbContextOptions<checkersdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Board> Boards { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql($"Host={Program.PsqlHostname};Username={Program.PsqlUser};Password={Program.PsqlPassword};Database={Program.PsqlCatalogName}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.ToTable("board");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Boardspaces)
                    .HasMaxLength(500)
                    .HasColumnName("boardspaces");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.ToTable("player");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Isturn).HasColumnName("isturn");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
