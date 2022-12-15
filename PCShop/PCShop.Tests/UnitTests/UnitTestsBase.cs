using PCShop.Infrastructure.Data;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using PCShop.Tests.Mocks;
using Monitor = PCShop.Infrastructure.Data.Models.Monitor;
using Type = PCShop.Infrastructure.Data.Models.GravitatingClasses.Type;

namespace PCShop.Tests.UnitTests
{
	public class UnitTestsBase
	{
		protected ApplicationDbContext data;

		[OneTimeSetUp]
		public void SetUpBase()
		{
			this.data = DatabaseMock.Instance;

			this.SeedDatabase();
		}

		[OneTimeTearDown]
		public void TearDownBase()
		{
			this.data.Dispose();
		}

		private void SeedDatabase()
		{
			var brands = this.CreateBrands();

			this.data.AddRange(brands);

			var cpus = this.CreateCPUs();

			this.data.AddRange(cpus);

			var rams = this.CreateRAMs();

			this.data.AddRange(rams);

			var ssdCapacities = this.CreateSSDCapacities();

			this.data.AddRange(ssdCapacities);

			var videoCards = this.CreateVideoCards();

			this.data.AddRange(videoCards);

			var types = this.CreateTypes();

			this.data.AddRange(types);

			var displaySizes = CreateDisplaySizes();

			this.data.AddRange(displaySizes);

			var laptops = this.CreateLaptops();

			this.data.AddRange(laptops);

			var resolutions = this.CreateResolutions();

			this.data.AddRange(resolutions);

			var refreshRates = this.CreateRefreshRates();

			this.data.AddRange(refreshRates);

			var monitors = this.CreateMonitors();

			this.data.AddRange(monitors);

			var keyboards = this.CreateKeyboards();

			this.data.AddRange(keyboards);

			var user = new User() { Id = "User1" };

			this.data.Add(user);

			var client = new Client() { Id = 1, UserId = "User1" };

			this.data.Add(client);

			this.data.SaveChanges();
		}

		private IEnumerable<Keyboard> CreateKeyboards()
		{
			return new List<Keyboard>()
			{
				new Keyboard()
				{
					Id = 1,
					BrandId = 1,
					Price = 1000.00M,
					IsWireless = true,
					TypeId = 1,
					Warranty = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Keyboard()
				{
					Id = 2,
					BrandId = 2,
					Price = 2000.00M,
					IsWireless = false,
					TypeId = 2,
					Warranty = 2,
					Quantity = 2,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Keyboard()
				{
					Id = 3,
					BrandId = 3,
					Price = 3000.00M,
					IsWireless = true,
					TypeId = 3,
					Warranty = 3,
					Quantity = 3,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Keyboard()
				{
					Id = 4,
					BrandId = 1,
					Price = 4000.00M,
					IsWireless = false,
					TypeId = 1,
					Warranty = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
					SellerId = 1,
				},
				new Keyboard()
				{
					Id = 5,
					BrandId = 1,
					Price = 5000.00M,
					IsWireless = true,
					TypeId = 1,
					Warranty = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
				},
			};
		}

		private IEnumerable<Monitor> CreateMonitors()
		{
			return new List<Monitor>()
			{
				new Monitor()
				{
					Id = 1,
					BrandId = 1,
					Price = 1000.00M,
					DisplaySizeId = 1,
					TypeId = 1,
					ResolutionId = 1,
					RefreshRateId = 1,
					Warranty = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Monitor()
				{
					Id = 2,
					BrandId = 2,
					Price = 2000.00M,
					DisplaySizeId = 2,
					TypeId = 2,
					ResolutionId = 2,
					RefreshRateId = 2,
					Warranty = 2,
					Quantity = 2,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Monitor()
				{
					Id = 3,
					BrandId = 3,
					Price = 3000.00M,
					DisplaySizeId = 3,
					TypeId = 3,
					ResolutionId = 3,
					RefreshRateId = 3,
					Warranty = 3,
					Quantity = 3,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Monitor()
				{
					Id = 4,
					BrandId = 1,
					Price = 4000.00M,
					DisplaySizeId = 1,
					TypeId = 1,
					ResolutionId = 1,
					RefreshRateId = 1,
					Warranty = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
					SellerId = 1,
				},
				new Monitor()
				{
					Id = 5,
					BrandId = 1,
					Price = 5000.00M,
					DisplaySizeId = 1,
					TypeId = 1,
					ResolutionId = 1,
					RefreshRateId = 1,
					Warranty = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
				},
			};
		}

		private IEnumerable<RefreshRate> CreateRefreshRates()
		{
			return new List<RefreshRate>()
			{
				new RefreshRate() { Id = 1, Value = 1 },
				new RefreshRate() { Id = 2, Value = 2 },
				new RefreshRate() { Id = 3, Value = 3 },
			};
		}

		private IEnumerable<Resolution> CreateResolutions()
		{
			return new List<Resolution>()
			{
				new Resolution() { Id = 1, Value = "1000x1000" },
				new Resolution() { Id = 2, Value = "2000x2000" },
				new Resolution() { Id = 3, Value = "3000x3000" },
			};
		}

		private IEnumerable<Laptop> CreateLaptops()
		{
			return new List<Laptop>()
			{
				new Laptop()
				{
					Id = 1,
					BrandId = 1,
					CPUId = 1,
					RAMId = 1,
					SSDCapacityId = 1,
					VideoCardId = 1,
					Price = 1000.00M,
					TypeId = 1,
					DisplaySizeId = 1,
					Warranty = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Laptop()
				{
					Id = 2,
					BrandId = 2,
					CPUId = 2,
					RAMId = 2,
					SSDCapacityId = 2,
					VideoCardId = 2,
					Price = 2000.00M,
					DisplaySizeId = 2,
					Warranty = 2,
					TypeId = 2,
					Quantity = 2,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Laptop()
				{
					Id = 3,
					BrandId = 3,
					CPUId = 3,
					RAMId = 3,
					SSDCapacityId = 3,
					VideoCardId = 3,
					Price = 3000.00M,
					DisplaySizeId = 3,
					Warranty = 3,
					TypeId = 3,
					Quantity = 3,
					AddedOn = DateTime.UtcNow.Date,
				},
				new Laptop()
				{
					Id = 4,
					BrandId = 1,
					CPUId = 1,
					RAMId = 1,
					SSDCapacityId = 1,
					VideoCardId = 1,
					Price = 4000.00M,
					DisplaySizeId = 1,
					Warranty = 0,
					TypeId = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
					SellerId = 1,
				},
				new Laptop()
				{
					Id = 5,
					BrandId = 1,
					CPUId = 1,
					RAMId = 1,
					SSDCapacityId = 1,
					VideoCardId = 1,
					Price = 5000.00M,
					DisplaySizeId = 1,
					Warranty = 1,
					TypeId = 1,
					Quantity = 1,
					AddedOn = DateTime.UtcNow.Date,
				},
			};
		}

		private IEnumerable<DisplaySize> CreateDisplaySizes()
		{
			return new List<DisplaySize>()
			{
				new DisplaySize() { Id = 1, Value = 1 },
				new DisplaySize() { Id = 2, Value = 2 },
				new DisplaySize() { Id = 3, Value = 3 },
			};
		}

		private IEnumerable<Type> CreateTypes()
		{
			return new List<Type>()
			{
				new Type() { Id = 1, Name = "Type1" },
				new Type() { Id = 2, Name = "Type2" },
				new Type() { Id = 3, Name = "Type3" },
			};
		}

		private IEnumerable<VideoCard> CreateVideoCards()
		{
			return new List<VideoCard>()
			{
				new VideoCard() { Id = 1, Name = "VideoCard1" },
				new VideoCard() { Id = 2, Name = "VideoCard2" },
				new VideoCard() { Id = 3, Name = "VideoCard3" },
			};
		}

		private IEnumerable<SSDCapacity> CreateSSDCapacities()
		{
			return new List<SSDCapacity>()
			{
				new SSDCapacity() { Id = 1, Value = 1 },
				new SSDCapacity() { Id = 2, Value = 2 },
				new SSDCapacity() { Id = 3, Value = 3 },
			};
		}

		private IEnumerable<RAM> CreateRAMs()
		{
			return new List<RAM>()
			{
				new RAM() { Id = 1, Value = 1 },
				new RAM() { Id = 2, Value = 2 },
				new RAM() { Id = 3, Value = 3 },
			};
		}

		private IEnumerable<CPU> CreateCPUs()
		{
			return new List<CPU>()
			{
				new CPU() { Id = 1, Name = "CPU1" },
				new CPU() { Id = 2, Name = "CPU2" },
				new CPU() { Id = 3, Name = "CPU3" },
			};
		}

		private IEnumerable<Brand> CreateBrands()
		{
			return new List<Brand>()
			{
				new Brand() { Id = 1, Name = "Brand1" },
				new Brand() { Id = 2, Name = "Brand2" },
				new Brand() { Id = 3, Name = "Brand3" },
			};
		}
	}
}
