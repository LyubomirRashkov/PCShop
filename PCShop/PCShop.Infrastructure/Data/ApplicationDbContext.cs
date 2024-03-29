﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCShop.Infrastructure.Data.Configuration;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Infrastructure.Data
{
	/// <summary>
	/// ApplicationDbContext model
	/// </summary>
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		private readonly bool seedDb;

		/// <summary>
		/// Constructor of ApplicationDbContext
		/// </summary>
		/// <param name="options">The DbContextOptions<c>ApplicationDbContext</c></param>
		/// <param name="seed">A flag indicating whether the seed methods should be invoked</param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool seed = true)
			: base(options)
		{
			if (this.Database.IsRelational())
			{
				this.Database.Migrate();
			}
			else
			{
				this.Database.EnsureCreated();
			}

			this.seedDb = seed;
		}

		/// <summary>
		/// Property that represents a collection of Clients
		/// </summary>
		public DbSet<Client> Clients { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of laptops
		/// </summary>
		public DbSet<Laptop> Laptops { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of monitors
		/// </summary>
		public DbSet<Monitor> Monitors { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of keyboards
		/// </summary>
		public DbSet<Keyboard> Keyboards { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of mice
		/// </summary>
		public DbSet<Mouse> Mice { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of headphones
		/// </summary>
		public DbSet<Headphone> Headphones { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of microphones
		/// </summary>
		public DbSet<Microphone> Microphones { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of brands
		/// </summary>
		public DbSet<Brand> Brands { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of colors
		/// </summary>
		public DbSet<Color> Colors { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of CPUs
		/// </summary>
		public DbSet<CPU> CPUs { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of display coverages
		/// </summary>
		public DbSet<DisplayCoverage> DisplayCoverages { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of display sizes
		/// </summary>
		public DbSet<DisplaySize> DisplaySizes { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of display technologies
		/// </summary>
		public DbSet<DisplayTechnology> DisplayTechnologies { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of formats
		/// </summary>
		public DbSet<Format> Formats { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of RAMs
		/// </summary>
		public DbSet<RAM> RAMs { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of refresh rates
		/// </summary>
		public DbSet<RefreshRate> RefreshRates { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of resolutions
		/// </summary>
		public DbSet<Resolution> Resolutions { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of sensitivities
		/// </summary>
		public DbSet<Sensitivity> Sensitivities { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of SSD capacities
		/// </summary>
		public DbSet<SSDCapacity> SSDCapacities { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of types
		/// </summary>
		public DbSet<Type> Types { get; set; } = null!;

		/// <summary>
		/// Property that represents a collection of video cards
		/// </summary>
		public DbSet<VideoCard> VideoCards { get; set; } = null!;

		/// <summary>
		/// Describes what needs to be done when creating the models (Fluent API)
		/// </summary>
		/// <param name="builder">The builder being used to construct the model for this context</param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			if (this.seedDb)
			{
				builder.ApplyConfiguration(new RoleConfiguration());

				builder.ApplyConfiguration(new UserConfiguration());

				builder.ApplyConfiguration(new ClientConfiguration());
			}

			base.OnModelCreating(builder);
		}
	}
}