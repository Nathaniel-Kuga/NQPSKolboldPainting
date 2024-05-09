using System;
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
            entity.HasKey(e => e.Id).HasName("PK__Company__3214EC27D5744FAA");
        });

        modelBuilder.Entity<KoboldUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoboldUs__3214EC079ECB7E11");

            entity.HasMany(d => d.Paints).WithMany(p => p.KoboldUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "OwnedPaint",
                    r => r.HasOne<Paint>().WithMany()
                        .HasForeignKey("PaintId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("OwnedPaint_FK_PaintID"),
                    l => l.HasOne<KoboldUser>().WithMany()
                        .HasForeignKey("KoboldUserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("OwnedPaint_FK_KoboldUserID"),
                    j =>
                    {
                        j.HasKey("KoboldUserId", "PaintId").HasName("PK__OwnedPai__5DE13D0F1524294B");
                        j.ToTable("OwnedPaint");
                        j.IndexerProperty<int>("KoboldUserId").HasColumnName("KoboldUserID");
                        j.IndexerProperty<int>("PaintId").HasColumnName("PaintID");
                    });
        });

        modelBuilder.Entity<Paint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paints__3214EC276F2F3F5A");

            entity.HasOne(d => d.Company).WithMany(p => p.Paints).HasConstraintName("Paints_FK_CompanyID");

            entity.HasOne(d => d.PaintType).WithMany(p => p.Paints).HasConstraintName("Paints_FK_PaintTypeID");
        });
        modelBuilder.Entity<OwnedPaint>().HasKey(op => new { op.KoboldUserId, op.PaintId });
        modelBuilder.Entity<PaintRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaintRec__3214EC273E2A48F9");

            entity.HasOne(d => d.KoboldUser).WithMany(p => p.PaintRecipes).HasConstraintName("PaintRecipes_FK_KoboldUserID");
        });

        modelBuilder.Entity<PaintType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaintTyp__3214EC27A78E4A55");
        });

        modelBuilder.Entity<PaintsForRecipe>(entity =>
        {
            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("PaintsForRecipe_FK_PaintID");

            entity.HasOne(d => d.Recipe).WithMany().HasConstraintName("PaintsForRecipe_FK_RecipeID");
        });

        modelBuilder.Entity<RefillPaint>(entity =>
        {
            entity.HasOne(d => d.KoboldUser).WithMany().HasConstraintName("RefillPaint_FK_KoboldUserID");

            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("RefillPaint_FK_PaintID");
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasOne(d => d.KoboldUser).WithMany().HasConstraintName("Tutorials_FK_KoboldUserID");
        });

        modelBuilder.Entity<WantedPaint>(entity =>
        {
            entity.HasOne(d => d.KoboldUser).WithMany().HasConstraintName("WantedPaint_FK_KoboldUserID");

            entity.HasOne(d => d.Paint).WithMany().HasConstraintName("WantedPaint_FK_PaintID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
