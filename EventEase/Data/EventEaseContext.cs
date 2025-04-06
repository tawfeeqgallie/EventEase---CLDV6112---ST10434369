namespace EventEase.Data;

using EventEase.Models;
using Microsoft.EntityFrameworkCore;

public class EventEaseContext : DbContext
{
    public EventEaseContext(DbContextOptions<EventEaseContext> options)
        : base(options)
    { }

    public DbSet<Venue> Venues { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure primary keys
        modelBuilder.Entity<Event>().HasKey(e => e.EventId);
        modelBuilder.Entity<Venue>().HasKey(v => v.VenueId);
        modelBuilder.Entity<Booking>().HasKey(b => b.BookingId);

        // Event-Venue relationship (1 Venue → Many Events)
        modelBuilder.Entity<Event>()
        .HasOne(e => e.Venue)
        .WithMany(v => v.Events)
        .HasForeignKey(e => e.VenueId)
        .OnDelete(DeleteBehavior.Cascade);

        // Booking-Event relationship (1 Event → Many Bookings)
        modelBuilder.Entity<Booking>()
        .HasOne(b => b.Event)
        .WithMany(e => e.Bookings)
        .HasForeignKey(b => b.EventId)
        .OnDelete(DeleteBehavior.Restrict);

        // Booking-Venue relationship (1 Venue → Many Bookings)
        modelBuilder.Entity<Booking>()
        .HasOne(b => b.Venue)
        .WithMany()
        .HasForeignKey(b => b.VenueId)
        .OnDelete(DeleteBehavior.Restrict);

        // OPTIONAL: Use singular table names (if preferred)
        modelBuilder.Entity<Event>().ToTable("Event");
        modelBuilder.Entity<Venue>().ToTable("Venue");
        modelBuilder.Entity<Booking>().ToTable("Booking");
    }
}
 