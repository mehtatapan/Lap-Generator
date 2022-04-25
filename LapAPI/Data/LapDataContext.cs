using LapAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LapAPI.Data
{
    public class LapDataContext : DbContext
    {
        public LapDataContext(DbContextOptions<LapDataContext> options)
            : base(options)
        {

        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<LapTime> LapTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add a unique index to the OHIP Number
            modelBuilder.Entity<Driver>()
            .HasIndex(p => p.CarNum)
            .IsUnique();

            //Restrict Cascade Delete
            modelBuilder.Entity<Driver>()
                .HasMany(p => p.LapTime)
                .WithOne(d => d.Driver)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
