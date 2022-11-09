using Microsoft.EntityFrameworkCore;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;
using static PCShop.DataSeeder.Constant.ConfigurationConstants;

namespace PCShop.DataSeeder
{
    /// <summary>
    /// The "DbContext" model used for seeding the database
    /// </summary>
    internal class PCShopDbContext : DbContext
    {
        /// <summary>
        /// Property that represents a collection of laptops
        /// </summary>
        internal DbSet<Laptop> Laptops { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of monitors
        /// </summary>
        internal DbSet<Monitor> Monitors { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of keyboards
        /// </summary>
        internal DbSet<Keyboard> Keyboards { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of mice
        /// </summary>
        internal DbSet<Mouse> Mice { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of headphones
        /// </summary>
        internal DbSet<Headphone> Headphones { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of microphones
        /// </summary>
        internal DbSet<Microphone> Microphones { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of brands
        /// </summary>
        internal DbSet<Brand> Brands { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of colors
        /// </summary>
        internal DbSet<Color> Colors { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of CPUs
        /// </summary>
        internal DbSet<CPU> CPUs { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of display coverages
        /// </summary>
        internal DbSet<DisplayCoverage> DisplayCoverages { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of display sizes
        /// </summary>
        internal DbSet<DisplaySize> DisplaySizes { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of display technologies
        /// </summary>
        internal DbSet<DisplayTechnology> DisplayTechnologies { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of formats
        /// </summary>
        internal DbSet<Format> Formats { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of RAMs
        /// </summary>
        internal DbSet<RAM> RAMs { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of refresh rates
        /// </summary>
        internal DbSet<RefreshRate> RefreshRates { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of resolutions
        /// </summary>
        internal DbSet<Resolution> Resolutions { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of sensitivities
        /// </summary>
        internal DbSet<Sensitivity> Sensitivities { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of SSD capacities
        /// </summary>
        internal DbSet<SSDCapacity> SSDCapacities { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of types
        /// </summary>
        internal DbSet<Type> Types { get; set; } = null!;

        /// <summary>
        /// Property that represents a collection of video cards
        /// </summary>
        internal DbSet<VideoCard> VideoCards { get; set; } = null!;

        /// <summary>
        /// Configures the settings for establishing a connection with the database
        /// </summary>
        /// <param name="optionsBuilder">The DbContextOptionsBuilder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        /// <summary>
        /// Describes what needs to be done when creating the models (Fluent API)
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
