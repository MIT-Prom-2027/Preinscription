using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Preinscription.Models;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faculte> Facultes { get; set; }

    public virtual DbSet<Mention> Mentions { get; set; }

    public virtual DbSet<Parcour> Parcours { get; set; }

    public virtual DbSet<Preinscription> Preinscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // 
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("faculte_pkey");

            entity.ToTable("faculte");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('faculte_id_seq1'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.NomFaculte)
                .HasMaxLength(100)
                .HasColumnName("nom_faculte");
        });

        modelBuilder.Entity<Mention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mention_pkey");

            entity.ToTable("mention");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('mention_id_seq1'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.IdFaculte).HasColumnName("id_faculte");
            entity.Property(e => e.NomMention)
                .HasMaxLength(100)
                .HasColumnName("nom_mention");

            entity.HasOne(d => d.IdFaculteNavigation).WithMany(p => p.Mentions)
                .HasForeignKey(d => d.IdFaculte)
                .HasConstraintName("mention_id_faculte_fkey");
        });

        modelBuilder.Entity<Parcour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("parcours_pkey");

            entity.ToTable("parcours");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('parcours_id_seq1'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.IdMention).HasColumnName("id_mention");
            entity.Property(e => e.NomParcours)
                .HasMaxLength(100)
                .HasColumnName("nom_parcours");

            entity.HasOne(d => d.IdMentionNavigation).WithMany(p => p.Parcours)
                .HasForeignKey(d => d.IdMention)
                .HasConstraintName("parcours_id_mention_fkey");
        });

        modelBuilder.Entity<Preinscription>(entity =>
        {
            entity.HasKey(e => new { e.NumBacc, e.AnneeBacc }).HasName("preinscription_pkey");

            entity.ToTable("preinscription");

            entity.HasIndex(e => e.Tel, "preinscription_tel_key").IsUnique();

            entity.Property(e => e.NumBacc).HasColumnName("num_bacc");
            entity.Property(e => e.AnneeBacc).HasColumnName("annee_bacc");
            entity.Property(e => e.CheminPreuvePaiement).HasColumnName("chemin_preuve_paiement");
            entity.Property(e => e.DatePreinscription)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("date_preinscription");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.EstValide)
                .HasDefaultValue(false)
                .HasColumnName("est_valide");
            entity.Property(e => e.IdParcours).HasColumnName("id_parcours");
            entity.Property(e => e.RecuBancaire)
                .HasMaxLength(100)
                .HasColumnName("recu_bancaire");
            entity.Property(e => e.Tel)
                .HasMaxLength(100)
                .HasColumnName("tel");

            entity.HasOne(d => d.IdParcoursNavigation).WithMany(p => p.Preinscriptions)
                .HasForeignKey(d => d.IdParcours)
                .HasConstraintName("preinscription_id_parcours_fkey");
        });
        modelBuilder.HasSequence<int>("faculte_id_seq");
        modelBuilder.HasSequence<int>("mention_id_seq");
        modelBuilder.HasSequence<int>("parcours_id_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
