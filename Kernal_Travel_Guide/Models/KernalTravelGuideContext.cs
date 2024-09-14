using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kernal_Travel_Guide.Models;

public partial class KernalTravelGuideContext : DbContext
{
    public KernalTravelGuideContext()
    {
    }

    public KernalTravelGuideContext(DbContextOptions<KernalTravelGuideContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Resort> Resorts { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<TouristSpot> TouristSpots { get; set; }

    public virtual DbSet<TravelInfo> TravelInfos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Kernal_travel_Guide;User ID=sa;Password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC27DA9C1F3B");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D10534613BED5D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF668B06C2B");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedback__UserID__33D4B598");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotels__46023BBF3D91734E");

            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PriceRange).HasMaxLength(50);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F04CCD72BA5");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.ReservationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ResortId).HasColumnName("ResortID");
            entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");
            entity.Property(e => e.SpecialRequests).HasColumnType("text");
            entity.Property(e => e.TouristSpotId).HasColumnName("TouristSpotID");
            entity.Property(e => e.TravelInfoId).HasColumnName("TravelInfoID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__Reservati__Hotel__398D8EEE");

            entity.HasOne(d => d.Resort).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ResortId)
                .HasConstraintName("FK__Reservati__Resor__3B75D760");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK__Reservati__Resta__3A81B327");

            entity.HasOne(d => d.TouristSpot).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TouristSpotId)
                .HasConstraintName("FK__Reservati__Touri__38996AB5");

            entity.HasOne(d => d.TravelInfo).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TravelInfoId)
                .HasConstraintName("FK__Reservati__Trave__3C69FB99");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__37A5467C");
        });

        modelBuilder.Entity<Resort>(entity =>
        {
            entity.HasKey(e => e.ResortId).HasName("PK__Resorts__7D2D742E80D51F00");

            entity.Property(e => e.ResortId).HasColumnName("ResortID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PriceRange).HasMaxLength(50);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__87454CB5F7A8EDC5");

            entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");
            entity.Property(e => e.CuisineType).HasMaxLength(100);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TouristSpot>(entity =>
        {
            entity.HasKey(e => e.TouristSpotId).HasName("PK__TouristS__4A82D4D746BB2DB0");

            entity.Property(e => e.TouristSpotId).HasColumnName("TouristSpotID");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TravelInfo>(entity =>
        {
            entity.HasKey(e => e.TravelInfoId).HasName("PK__TravelIn__444755C8A46703AC");

            entity.ToTable("TravelInfo");

            entity.Property(e => e.TravelInfoId).HasColumnName("TravelInfoID");
            entity.Property(e => e.Availability).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ModeOfTransport).HasMaxLength(100);
            entity.Property(e => e.PriceRange).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC5F9C7440");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105349AD5E8E1").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
