using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<SavedTrip> SavedTrips { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Climate> Climates { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<TravelType> TravelTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasMany(a => a.Trips)
                .WithOne(t => t.Activity)
                .HasForeignKey(t => t.ActivityId);

            modelBuilder.Entity<User>()
                .HasMany(s => s.SavedTrips)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.SavedTrips)
                .WithOne(s => s.Trip)
                .HasForeignKey(s => s.TripId);
         
            modelBuilder.Entity<Climate>()
                .HasMany(c => c.Trips)
                .WithOne(t => t.Climate)
                .HasForeignKey(t => t.ClimateId);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.Trips)
                .WithOne(t => t.Location)
                .HasForeignKey(t => t.LocationId);
            
            modelBuilder.Entity<TravelType>()
                .HasMany(v => v.Trips)
                .WithOne(t => t.TravelType)
                .HasForeignKey(t => t.TravelTypeId);    

            modelBuilder.Entity<SavedTrip>(entity =>
                {
                    entity.HasKey(e => e.UId);
                });
        }
    }
}