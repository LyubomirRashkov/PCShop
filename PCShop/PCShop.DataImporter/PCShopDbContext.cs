using Microsoft.EntityFrameworkCore;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;
using static PCShop.DataImporter.Constants.Configuration;

namespace PCShop.DataImporter
{
    /// <summary>
    /// The "DbContext" class used for seeding the database
    /// </summary>
    public class PCShopDbContext : DbContext
    {
        /// <summary>
        /// Collection of laptops
        /// </summary>
        public DbSet<Laptop> Laptops { get; set; } = null!;

        /// <summary>
        /// Collection of monitors
        /// </summary>
        public DbSet<Monitor> Monitors { get; set; } = null!;

        /// <summary>
        /// Collection of keyboards
        /// </summary>
        public DbSet<Keyboard> Keyboards { get; set; } = null!;

        /// <summary>
        /// Collection of mice
        /// </summary>
        public DbSet<Mouse> Mice { get; set; } = null!;

        /// <summary>
        /// Collection of headphones
        /// </summary>
        public DbSet<Headphone> Headphones { get; set; } = null!; 

        /// <summary>
        /// Collection of microphones
        /// </summary>
        public DbSet<Microphone> Microphones { get; set; } = null!;

        /// <summary>
        /// Collection of brands
        /// </summary>
        public DbSet<Brand> Brands { get; set; } = null!;

        /// <summary>
        /// Collection of colors
        /// </summary>
        public DbSet<Color> Colors { get; set; } = null!;

        /// <summary>
        /// Collection of CPUs
        /// </summary>
        public DbSet<CPU> CPUs { get; set; } = null!;

        /// <summary>
        /// Collection of display coverages
        /// </summary>
        public DbSet<DisplayCoverage> DisplayCoverages { get; set; } = null!;

        /// <summary>
        /// Collection of display sizes
        /// </summary>
        public DbSet<DisplaySize> DisplaySizes { get; set; } = null!;

        /// <summary>
        /// Collection of display technologies
        /// </summary>
        public DbSet<DisplayTechnology> DisplayTechnologies { get; set; } = null!;

        /// <summary>
        /// Collection of formats
        /// </summary>
        public DbSet<Format> Formats { get; set; } = null!;

        /// <summary>
        /// Collection of RAMs
        /// </summary>
        public DbSet<RAM> RAMs { get; set; } = null!;

        /// <summary>
        /// Collection of refresh rates
        /// </summary>
        public DbSet<RefreshRate> RefreshRates { get; set; } = null!;

        /// <summary>
        /// Collection of resolutions
        /// </summary>
        public DbSet<Resolution> Resolutions { get; set; } = null!;

        /// <summary>
        /// Collection of sensitivities
        /// </summary>
        public DbSet<Sensitivity> Sensitivities { get; set; } = null!;

        /// <summary>
        /// Collection of SSD capacities
        /// </summary>
        public DbSet<SSDCapacity> SSDCapacities { get; set; } = null!;

        /// <summary>
        /// Collection of types
        /// </summary>
        public DbSet<Type> Types { get; set; } = null!;

        /// <summary>
        /// Collection of video cards
        /// </summary>
        public DbSet<VideoCard> VideoCards { get; set; } = null!;

        /// <summary>
        /// Describes how to connect to the Db provider
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        /// <summary>
        /// Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
