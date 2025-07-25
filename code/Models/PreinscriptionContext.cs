using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace preinscription.Models;

public partial class PreinscriptionContext : DbContext
{
    public PreinscriptionContext()
    {
    }

    public PreinscriptionContext(DbContextOptions<PreinscriptionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faculte> Facultes { get; set; }

    public virtual DbSet<Mention> Mentions { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Parcour> Parcours { get; set; }

    public virtual DbSet<Preinscription> Preinscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Charge la configuration depuis appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("PreinscriptionDatabase");
            optionsBuilder.UseMySql(
                connectionString, 
                ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Faculte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("faculte");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NomFaculte)
                .HasMaxLength(100)
                .HasColumnName("nom_faculte");
        });

        modelBuilder.Entity<Mention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mention");

            entity.HasIndex(e => e.IdFaculte, "id_faculte");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdFaculte).HasColumnName("id_faculte");
            entity.Property(e => e.NomMention)
                .HasMaxLength(100)
                .HasColumnName("nom_mention");

            entity.HasOne(d => d.IdFaculteNavigation).WithMany(p => p.Mentions)
                .HasForeignKey(d => d.IdFaculte)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mention_ibfk_1");
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("option");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(5)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Parcour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("parcours");

            entity.HasIndex(e => e.IdMention, "id_mention");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMention).HasColumnName("id_mention");
            entity.Property(e => e.NomParcours)
                .HasMaxLength(100)
                .HasColumnName("nom_parcours");

            entity.HasOne(d => d.IdMentionNavigation).WithMany(p => p.Parcours)
                .HasForeignKey(d => d.IdMention)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("parcours_ibfk_1");
        });

        modelBuilder.Entity<Preinscription>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("preinscription");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
