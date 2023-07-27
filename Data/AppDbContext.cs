using DiazFrontDeskApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiazFrontDeskApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageArea> PackageAreas { get; set; }
        public DbSet<PackageStatus> PackageStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PackageStatus>().HasData(
                new PackageStatus
                {
                    PackageStatusId = 1,
                    PackageStatusName = "Stored"
                });

            modelBuilder.Entity<PackageStatus>().HasData(
                new PackageStatus
                {
                    PackageStatusId = 2,
                    PackageStatusName = "Retrieved"
                });

            modelBuilder.Entity<PackageArea>().HasData(
                new PackageArea
                {
                    PackageAreaId = 1,
                    PackageAreaType = "Small",
                    MaxCapacity = 10,
                    CurrentCapacity = 0,
                });

            modelBuilder.Entity<PackageArea>().HasData(
                new PackageArea
                {
                    PackageAreaId = 2,
                    PackageAreaType = "Medium",
                    MaxCapacity = 5,
                    CurrentCapacity = 0,
                });

            modelBuilder.Entity<PackageArea>().HasData(
                new PackageArea
                {
                    PackageAreaId = 3,
                    PackageAreaType = "Large",
                    MaxCapacity = 3,
                    CurrentCapacity = 0,
                });
        }
    }
}
