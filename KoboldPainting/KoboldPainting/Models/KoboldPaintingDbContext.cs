﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoboldPainting.Models;

public partial class KoboldPaintingDbContext : DbContext
{
    public KoboldPaintingDbContext()
    {
    }

    public KoboldPaintingDbContext(DbContextOptions<KoboldPaintingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<KoboldUser> KoboldUsers { get; set; }

    public virtual DbSet<OwnedPaint> OwnedPaints { get; set; }

    public virtual DbSet<Paint> Paints { get; set; }

    public virtual DbSet<PaintRecipe> PaintRecipes { get; set; }

    public virtual DbSet<PaintType> PaintTypes { get; set; }

    public virtual DbSet<PaintsForRecipe> PaintsForRecipes { get; set; }

    public virtual DbSet<RefillPaint> RefillPaints { get; set; }

    public virtual DbSet<Tutorial> Tutorials { get; set; }

    public virtual DbSet<WantedPaint> WantedPaints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC27F78F4210");
        });

        modelBuilder.Entity<KoboldUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoboldUs__3214EC0720B2393E");
        });

        modelBuilder.Entity<OwnedPaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OwnedPai__3214EC07674AE45F");

            entity.HasOne(d => d.KoboldUser).WithMany(p => p.OwnedPaints).HasConstraintName("OwnedPaint_FK_KoboldUserID");

            entity.HasOne(d => d.Paint).WithMany(p => p.OwnedPaints).HasConstraintName("OwnedPaint_FK_PaintID");
        });

        modelBuilder.Entity<Paint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paints__3214EC276D36A8D9");

            entity.HasOne(d => d.Company).WithMany(p => p.Paints).HasConstraintName("Paints_FK_CompanyID");

            entity.HasOne(d => d.PaintType).WithMany(p => p.Paints).HasConstraintName("Paints_FK_PaintTypeID");
        });

        modelBuilder.Entity<PaintRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaintRec__3214EC27DEED63A9");

            entity.HasOne(d => d.KoboldUser).WithMany(p => p.PaintRecipes).HasConstraintName("PaintRecipes_FK_KoboldUserID");
        });

        modelBuilder.Entity<PaintType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaintTyp__3214EC2710DB1A96");
        });

        modelBuilder.Entity<PaintsForRecipe>(entity =>
        {
            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("PaintsForRecipe_FK_PaintID");

            entity.HasOne(d => d.Recipe).WithMany().HasConstraintName("PaintsForRecipe_FK_RecipeID");
        });

        modelBuilder.Entity<RefillPaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefillPa__3214EC07EE989542");

            entity.HasOne(d => d.KoboldUser).WithMany(p => p.RefillPaints).HasConstraintName("RefillPaint_FK_KoboldUserID");

            entity.HasOne(d => d.Paint).WithMany(p => p.RefillPaints).HasConstraintName("RefillPaint_FK_PaintID");
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasOne(d => d.KoboldUser).WithMany().HasConstraintName("Tutorials_FK_KoboldUserID");
        });

        modelBuilder.Entity<WantedPaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WantedPa__3214EC07836AE284");

            entity.HasOne(d => d.KoboldUser).WithMany(p => p.WantedPaints).HasConstraintName("WantedPaint_FK_KoboldUserID");

            entity.HasOne(d => d.Paint).WithMany(p => p.WantedPaints).HasConstraintName("WantedPaint_FK_PaintID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
