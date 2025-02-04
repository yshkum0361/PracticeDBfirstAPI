using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PracticeDBfirstAPI.Models;

namespace PracticeDBfirstAPI.Data;

public partial class YashContext : DbContext
{
    public YashContext()
    {
    }

    public YashContext(DbContextOptions<YashContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GameCharaterMst> GameCharaterMsts { get; set; }

    public virtual DbSet<GameDetailsMst> GameDetailsMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameCharaterMst>(entity =>
        {
            entity.HasKey(e => e.GcId).HasName("PK__GameChar__BB8DD03775EDEB72");

            entity.ToTable("GameCharater_mst");

            entity.Property(e => e.GcId).HasColumnName("GC_id");
            entity.Property(e => e.FkGameId).HasColumnName("Fk_Game_id");
            entity.Property(e => e.Gcname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GCName");
            entity.Property(e => e.Power).HasDefaultValue("");

            entity.HasOne(d => d.FkGame).WithMany(p => p.GameCharaterMsts)
                .HasForeignKey(d => d.FkGameId)
                .HasConstraintName("FK_GameCharacter_Game");
        });

        modelBuilder.Entity<GameDetailsMst>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Game_Det__0930002661E28402");

            entity.ToTable("Game_Details_mst");

            entity.Property(e => e.GameId).HasColumnName("Game_id");
            entity.Property(e => e.GameName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Game_name");
            entity.Property(e => e.ReleaseYear).HasColumnName("Release_year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
