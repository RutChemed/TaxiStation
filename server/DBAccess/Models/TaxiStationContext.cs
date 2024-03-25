using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBAccess.Models;

public partial class TaxiStationContext : DbContext
{
    public TaxiStationContext(DbContextOptions<TaxiStationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DriverTemporaryLocation> DriverTemporaryLocations { get; set; }

    public virtual DbSet<HistoryTravel> HistoryTravels { get; set; }

    public virtual DbSet<OrderingTravel> OrderingTravels { get; set; }

    public virtual DbSet<PhysicalEmployeeDetail> PhysicalEmployeeDetails { get; set; }

    public virtual DbSet<TechnicalEmployeeDetail> TechnicalEmployeeDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DriverTemporaryLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DriverTe__3214EC0736735BCF");

            entity.ToTable("DriverTemporaryLocation");

            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Latitudes).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Longitudes).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.DriverNavigation).WithMany(p => p.DriverTemporaryLocations)
                .HasForeignKey(d => d.Driver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DriverTem__Drive__49C3F6B7");
        });

        modelBuilder.Entity<HistoryTravel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HistoryT__3214EC0768E4D33A");

            entity.ToTable("HistoryTravel");

            entity.Property(e => e.ClientPhone).HasMaxLength(255);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ExitLatitudes).HasMaxLength(255);
            entity.Property(e => e.ExitLongitudes).HasMaxLength(255);
            entity.Property(e => e.PassengersNum).HasDefaultValueSql("((4))");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TargetLatitudes).HasMaxLength(255);
            entity.Property(e => e.TargetLongitudes).HasMaxLength(255);

            entity.HasOne(d => d.DriverNavigation).WithMany(p => p.HistoryTravels)
                .HasForeignKey(d => d.Driver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HistoryTr__Drive__440B1D61");
        });

        modelBuilder.Entity<OrderingTravel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordering__3214EC078F9E2B68");

            entity.ToTable("OrderingTravel");

            entity.Property(e => e.ClientPhone).HasMaxLength(255);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ExitLatitudes).HasMaxLength(255);
            entity.Property(e => e.ExitLongitudes).HasMaxLength(255);
            entity.Property(e => e.PassengersNum).HasDefaultValueSql("((4))");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TargetLatitudes).HasMaxLength(255);
            entity.Property(e => e.TargetLongitudes).HasMaxLength(255);

            entity.HasOne(d => d.DriverNavigation).WithMany(p => p.OrderingTravels)
                .HasForeignKey(d => d.Driver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderingT__Drive__403A8C7D");
        });

        modelBuilder.Entity<PhysicalEmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Physical__3214EC072296359D");

            entity.Property(e => e.Available).HasDefaultValueSql("((1))");
            entity.Property(e => e.Latitudes).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Longitudes).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.NumPlaces).HasDefaultValueSql("((4))");

            entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.PhysicalEmployeeDetails)
                .HasForeignKey(d => d.Employee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhysicalE__Longi__3C69FB99");
        });

        modelBuilder.Entity<TechnicalEmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Technica__3214EC071DB21242");

            entity.Property(e => e.AddressLatitudes).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.AddressLongitudes).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasDefaultValueSql("('Driver')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
