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

    public virtual DbSet<Bachelier> Bacheliers { get; set; }

    public virtual DbSet<Centre> Centres { get; set; }

    public virtual DbSet<Etablissement> Etablissements { get; set; }

    public virtual DbSet<Faculte> Facultes { get; set; }

    public virtual DbSet<Matiere> Matieres { get; set; }

    public virtual DbSet<Mention> Mentions { get; set; }

    public virtual DbSet<Mention1> Mentions1 { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Option1> Options1 { get; set; }

    public virtual DbSet<Parcour> Parcours { get; set; }

    public virtual DbSet<Personne> Personnes { get; set; }

    public virtual DbSet<Preinscription> Preinscriptions { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=preinscription;uid=csb;pwd=12345678", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.5-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bachelier>(entity =>
        {
            entity.HasKey(e => e.IdBachelier).HasName("PRIMARY");

            entity.ToTable("bacheliers");

            entity.HasIndex(e => e.IdCentre, "id_centre");

            entity.HasIndex(e => e.IdEtablissement, "id_etablissement");

            entity.HasIndex(e => e.IdMention, "id_mention");

            entity.HasIndex(e => e.IdOption, "id_option");

            entity.HasIndex(e => e.IdPersonne, "id_personne");

            entity.Property(e => e.IdBachelier).HasColumnName("id_bachelier");
            entity.Property(e => e.Annee).HasColumnName("annee");
            entity.Property(e => e.IdCentre).HasColumnName("id_centre");
            entity.Property(e => e.IdEtablissement).HasColumnName("id_etablissement");
            entity.Property(e => e.IdMention).HasColumnName("id_mention");
            entity.Property(e => e.IdOption).HasColumnName("id_option");
            entity.Property(e => e.IdPersonne).HasColumnName("id_personne");
            entity.Property(e => e.Moyenne).HasColumnName("moyenne");
            entity.Property(e => e.NumeroCandidat)
                .HasColumnType("text")
                .HasColumnName("numero_candidat");

            entity.HasOne(d => d.IdCentreNavigation).WithMany(p => p.Bacheliers)
                .HasForeignKey(d => d.IdCentre)
                .HasConstraintName("bacheliers_ibfk_3");

            entity.HasOne(d => d.IdEtablissementNavigation).WithMany(p => p.Bacheliers)
                .HasForeignKey(d => d.IdEtablissement)
                .HasConstraintName("bacheliers_ibfk_4");

            entity.HasOne(d => d.IdMentionNavigation).WithMany(p => p.Bacheliers)
                .HasForeignKey(d => d.IdMention)
                .HasConstraintName("bacheliers_ibfk_5");

            entity.HasOne(d => d.IdOptionNavigation).WithMany(p => p.Bacheliers)
                .HasForeignKey(d => d.IdOption)
                .HasConstraintName("bacheliers_ibfk_2");

            entity.HasOne(d => d.IdPersonneNavigation).WithMany(p => p.Bacheliers)
                .HasForeignKey(d => d.IdPersonne)
                .HasConstraintName("bacheliers_ibfk_1");
        });

        modelBuilder.Entity<Centre>(entity =>
        {
            entity.HasKey(e => e.IdCentre).HasName("PRIMARY");

            entity.ToTable("centres");

            entity.HasIndex(e => e.IdProvince, "id_province");

            entity.Property(e => e.IdCentre).HasColumnName("id_centre");
            entity.Property(e => e.IdProvince).HasColumnName("id_province");
            entity.Property(e => e.NomCentre)
                .HasColumnType("text")
                .HasColumnName("nom_centre");

            entity.HasOne(d => d.IdProvinceNavigation).WithMany(p => p.Centres)
                .HasForeignKey(d => d.IdProvince)
                .HasConstraintName("centres_ibfk_1");
        });

        modelBuilder.Entity<Etablissement>(entity =>
        {
            entity.HasKey(e => e.IdEtablissement).HasName("PRIMARY");

            entity.ToTable("etablissements");

            entity.Property(e => e.IdEtablissement).HasColumnName("id_etablissement");
            entity.Property(e => e.NomEtablissement)
                .HasColumnType("text")
                .HasColumnName("nom_etablissement");
        });

        modelBuilder.Entity<Faculte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("faculte");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NomFaculte)
                .HasMaxLength(100)
                .HasColumnName("nom_faculte");
        });

        modelBuilder.Entity<Matiere>(entity =>
        {
            entity.HasKey(e => e.IdMatiere).HasName("PRIMARY");

            entity.ToTable("matieres");

            entity.Property(e => e.IdMatiere).HasColumnName("id_matiere");
            entity.Property(e => e.NomMatiere)
                .HasColumnType("text")
                .HasColumnName("nom_matiere");
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

        modelBuilder.Entity<Mention1>(entity =>
        {
            entity.HasKey(e => e.IdMention).HasName("PRIMARY");

            entity.ToTable("mentions");

            entity.Property(e => e.IdMention).HasColumnName("id_mention");
            entity.Property(e => e.Max)
                .HasDefaultValueSql("'20'")
                .HasColumnName("max");
            entity.Property(e => e.Min)
                .HasDefaultValueSql("'0'")
                .HasColumnName("min");
            entity.Property(e => e.NomMention)
                .HasColumnType("text")
                .HasColumnName("nom_mention");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PRIMARY");

            entity.ToTable("notes");

            entity.HasIndex(e => e.IdBachelier, "id_bachelier");

            entity.HasIndex(e => e.IdMatiere, "id_matiere");

            entity.Property(e => e.IdNote).HasColumnName("id_note");
            entity.Property(e => e.EstOptionnel)
                .HasDefaultValueSql("'0'")
                .HasColumnName("est_optionnel");
            entity.Property(e => e.IdBachelier).HasColumnName("id_bachelier");
            entity.Property(e => e.IdMatiere).HasColumnName("id_matiere");
            entity.Property(e => e.ValeurNote).HasColumnName("valeur_note");

            entity.HasOne(d => d.IdBachelierNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdBachelier)
                .HasConstraintName("notes_ibfk_2");

            entity.HasOne(d => d.IdMatiereNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdMatiere)
                .HasConstraintName("notes_ibfk_1");
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

        modelBuilder.Entity<Option1>(entity =>
        {
            entity.HasKey(e => e.IdOption).HasName("PRIMARY");

            entity.ToTable("options");

            entity.Property(e => e.IdOption).HasColumnName("id_option");
            entity.Property(e => e.Serie)
                .HasColumnType("text")
                .HasColumnName("serie");
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

        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.IdPersonne).HasName("PRIMARY");

            entity.ToTable("personnes");

            entity.Property(e => e.IdPersonne).HasColumnName("id_personne");
            entity.Property(e => e.DateNaissance).HasColumnName("date_naissance");
            entity.Property(e => e.LieuNaissance)
                .HasColumnType("text")
                .HasColumnName("lieu_naissance");
            entity.Property(e => e.NomPrenom)
                .HasColumnType("text")
                .HasColumnName("nom_prenom");
            entity.Property(e => e.Sexe)
                .HasColumnType("enum('F','M')")
                .HasColumnName("sexe");
        });

        modelBuilder.Entity<Preinscription>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("preinscription");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.IdProvince).HasName("PRIMARY");

            entity.ToTable("provinces");

            entity.Property(e => e.IdProvince).HasColumnName("id_province");
            entity.Property(e => e.NomProvince)
                .HasColumnType("text")
                .HasColumnName("nom_province");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
