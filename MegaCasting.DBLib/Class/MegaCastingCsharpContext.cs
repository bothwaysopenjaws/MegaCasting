using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MegaCasting.DBLib.Class;

public partial class MegaCastingCsharpContext : DbContext
{
    public MegaCastingCsharpContext()
    {
    }

    public MegaCastingCsharpContext(DbContextOptions<MegaCastingCsharpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityArtist> ActivityArtists { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<ContractType> ContractTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerContact> CustomerContacts { get; set; }

    public virtual DbSet<Mcuser> Mcusers { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<SalaryMan> SalaryMen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Activity");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ActivityArtist>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("ActivityArtist");

            entity.HasIndex(e => e.IdentifierActivity, "IX_ActivityArtist_IdentifierActivity");

            entity.HasIndex(e => e.IdentifierArtist, "IX_ActivityArtist_IdentifierArtist");

            entity.HasOne(d => d.IdentifierActivityNavigation).WithMany(p => p.ActivityArtists)
                .HasForeignKey(d => d.IdentifierActivity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityArtist_Activity");

            entity.HasOne(d => d.IdentifierArtistNavigation).WithMany(p => p.ActivityArtists)
                .HasForeignKey(d => d.IdentifierArtist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityArtist_Artist");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Artist");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("ContractType");

            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.ShortName).HasMaxLength(5);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Customer");

            entity.Property(e => e.AddressCity).HasMaxLength(50);
            entity.Property(e => e.AddressComplement).HasMaxLength(50);
            entity.Property(e => e.AddressRoad).HasMaxLength(50);
            entity.Property(e => e.AddressZipCode).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerContact>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("CustomerContact");

            entity.HasIndex(e => e.IdentifierCustomer, "IX_CustomerContact_IdentifierCustomer");

            entity.Property(e => e.Identifier).ValueGeneratedNever();

            entity.HasOne(d => d.IdentifierNavigation).WithOne(p => p.CustomerContact)
                .HasForeignKey<CustomerContact>(d => d.Identifier)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdentifierCustomerNavigation).WithMany(p => p.CustomerContacts)
                .HasForeignKey(d => d.IdentifierCustomer)
                .HasConstraintName("FK_CustomerContact_Customer");
        });

        modelBuilder.Entity<Mcuser>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("MCUser");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMail");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Offer");

            entity.HasIndex(e => e.IdentifierClient, "IX_Offer_IdentifierClient");

            entity.HasIndex(e => e.IdentifierContractType, "IX_Offer_IdentifierContractType");

            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdentifierClientNavigation).WithMany(p => p.Offers)
                .HasForeignKey(d => d.IdentifierClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offer_Client");

            entity.HasOne(d => d.IdentifierContractTypeNavigation).WithMany(p => p.Offers)
                .HasForeignKey(d => d.IdentifierContractType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offer_ContractType");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Partner");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SalaryMan>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("SalaryMan");

            entity.Property(e => e.Identifier).ValueGeneratedNever();

            entity.HasOne(d => d.IdentifierNavigation).WithOne(p => p.SalaryMan)
                .HasForeignKey<SalaryMan>(d => d.Identifier)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
