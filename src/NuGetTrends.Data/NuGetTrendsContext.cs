using System;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Catalog.Models;

namespace NuGetTrends.Data
{
    public class PackageDownload
    {
        public string PackageId { get; set; }
        public string PackageIdLowered { get; set; }
        public long? LatestDownloadCount { get; set; }
        public DateTime LatestDownloadCountCheckedUtc { get; set; }
        public string IconUrl { get; set; }
    }

    public class NuGetTrendsContext : BasePostgresContext
    {
        public NuGetTrendsContext(DbContextOptions<NuGetTrendsContext> options)
            : base(options)
        { }

        public DbSet<PackageDetailsCatalogLeaf> PackageDetailsCatalogLeafs { get; set; }
        public DbSet<Cursor> Cursors { get; set; }
        public DbSet<DailyDownload> DailyDownloads { get; set; }
        public DbSet<PackageDownload> PackageDownloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<DailyDownloadResult>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DailyDownload>()
                .HasKey(k => new { k.PackageId, k.Date });

            modelBuilder
                .Entity<Cursor>()
                .HasData(new Cursor
                {
                    Id = "Catalog",
                    Value = DateTimeOffset.MinValue
                });

            modelBuilder
                .Entity<PackageDetailsCatalogLeaf>()
                .HasIndex(p => new { p.PackageId, p.PackageVersion })
                .IsUnique();

            modelBuilder
                .Entity<PackageDetailsCatalogLeaf>()
                .HasIndex(p => p.PackageId);

            modelBuilder
                .Entity<PackageDetailsCatalogLeaf>()
                .HasMany(p => p.DependencyGroups)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<PackageDependencyGroup>()
                .HasMany(p => p.Dependencies)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<PackageDependency>()
                .HasIndex(p => p.DependencyId);

            modelBuilder
                .Entity<PackageDownload>()
                .HasKey(c => c.PackageId);

            modelBuilder
                .Entity<PackageDownload>()
                .HasIndex(c => c.PackageIdLowered)
                .IsUnique();

            modelBuilder.Entity<PackageDownload>()
                .Property(b => b.PackageIdLowered)
                .IsRequired();
        }
    }
}
