using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartRent.Models;

namespace SmartRent.Data;

public partial class SmartRentContext : DbContext
{
    public SmartRentContext()
    {
    }

    public SmartRentContext(DbContextOptions<SmartRentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AiSearchLog> AiSearchLogs { get; set; }

    public virtual DbSet<Apartment> Apartments { get; set; }

    public virtual DbSet<BlogPost> BlogPosts { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SmartRentDB"));
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AiSearchLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AI_Searc__5E5499A8D77E7D18");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.User).WithMany(p => p.AiSearchLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AI_SearchLogs_Users");
        });

        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.HasKey(e => e.ApartmentId).HasName("PK__Apartmen__CBDF5744B6F530DF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Owner).WithMany(p => p.Apartments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartments_Users");
        });

        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__BlogPost__AA1260389F2C69CD");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Author).WithMany(p => p.BlogPosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogPosts_Users");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACD4BDD625E");

            entity.Property(e => e.Commission).HasComputedColumnSql("([TotalAmount]*(0.1))", true);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status).HasDefaultValue("Pending");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Users");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings).HasConstraintName("FK_Bookings_Rooms");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFAADDEADFB6");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Users");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments).HasConstraintName("FK_Comments_BlogPosts");

            entity.HasOne(d => d.RoomSuggestion).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Comments_Rooms");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58C9523913");

            entity.Property(e => e.PaymentDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments).HasConstraintName("FK_Payments_Bookings");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__3286391908B99A82");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.Apartment).WithMany(p => p.Rooms).HasConstraintName("FK_Rooms_Apartments");
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__RoomImag__7516F4EC5FF6F0B4");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomImages).HasConstraintName("FK_RoomImages_Rooms");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC640428C8");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
