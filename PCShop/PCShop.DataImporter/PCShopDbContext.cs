using Microsoft.EntityFrameworkCore;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;
using static PCShop.DataSeeder.Constant.Configuration;

namespace PCShop.DataSeeder
{
    /// <summary>
    /// The "DbContext" class used for seeding the database
    /// </summary>
    internal class PCShopDbContext : DbContext
    {
        /// <summary>
        /// Collection of laptops
        /// </summary>
        internal DbSet<Laptop> Laptops { get; set; } = null!;

        /// <summary>
        /// Collection of monitors
        /// </summary>
        internal DbSet<Monitor> Monitors { get; set; } = null!;

        /// <summary>
        /// Collection of keyboards
        /// </summary>
        internal DbSet<Keyboard> Keyboards { get; set; } = null!;

        /// <summary>
        /// Collection of mice
        /// </summary>
        internal DbSet<Mouse> Mice { get; set; } = null!;

        /// <summary>
        /// Collection of headphones
        /// </summary>
        internal DbSet<Headphone> Headphones { get; set; } = null!;

        /// <summary>
        /// Collection of microphones
        /// </summary>
        internal DbSet<Microphone> Microphones { get; set; } = null!;

        /// <summary>
        /// Collection of brands
        /// </summary>
        internal DbSet<Brand> Brands { get; set; } = null!;

        /// <summary>
        /// Collection of colors
        /// </summary>
        internal DbSet<Color> Colors { get; set; } = null!;

        /// <summary>
        /// Collection of CPUs
        /// </summary>
        internal DbSet<CPU> CPUs { get; set; } = null!;

        /// <summary>
        /// Collection of display coverages
        /// </summary>
        internal DbSet<DisplayCoverage> DisplayCoverages { get; set; } = null!;

        /// <summary>
        /// Collection of display sizes
        /// </summary>
        internal DbSet<DisplaySize> DisplaySizes { get; set; } = null!;

        /// <summary>
        /// Collection of display technologies
        /// </summary>
        internal DbSet<DisplayTechnology> DisplayTechnologies { get; set; } = null!;

        /// <summary>
        /// Collection of formats
        /// </summary>
        internal DbSet<Format> Formats { get; set; } = null!;

        /// <summary>
        /// Collection of RAMs
        /// </summary>
        internal DbSet<RAM> RAMs { get; set; } = null!;

        /// <summary>
        /// Collection of refresh rates
        /// </summary>
        internal DbSet<RefreshRate> RefreshRates { get; set; } = null!;

        /// <summary>
        /// Collection of resolutions
        /// </summary>
        internal DbSet<Resolution> Resolutions { get; set; } = null!;

        /// <summary>
        /// Collection of sensitivities
        /// </summary>
        internal DbSet<Sensitivity> Sensitivities { get; set; } = null!;

        /// <summary>
        /// Collection of SSD capacities
        /// </summary>
        internal DbSet<SSDCapacity> SSDCapacities { get; set; } = null!;

        /// <summary>
        /// Collection of types
        /// </summary>
        internal DbSet<Type> Types { get; set; } = null!;

        /// <summary>
        /// Collection of video cards
        /// </summary>
        internal DbSet<VideoCard> VideoCards { get; set; } = null!;

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
