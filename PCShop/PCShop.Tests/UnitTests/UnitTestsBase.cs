using PCShop.Infrastructure.Data;
using PCShop.Infrastructure.Data.Models;
using PCShop.Infrastructure.Data.Models.Account;
using PCShop.Infrastructure.Data.Models.GravitatingClasses;
using PCShop.Tests.Mocks;
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
			var brands = new List<Brand>()
			{
				new Brand() { Id = 1, Name = "Brand1" },
				new Brand() { Id = 2, Name = "Brand2" },
				new Brand() { Id = 3, Name = "Brand3" },
			};

			this.data.AddRange(brands);

			var cpus = new List<CPU>()
			{
				new CPU() { Id = 1, Name = "CPU1" },
				new CPU() { Id = 2, Name = "CPU2" },
				new CPU() { Id = 3, Name = "CPU3" },
			};

			this.data.AddRange(cpus);

			var rams = new List<RAM>()
			{
				new RAM() { Id = 1, Value = 1 },
				new RAM() { Id = 2, Value = 2 },
				new RAM() { Id = 3, Value = 3 },
			};

			this.data.AddRange(rams);

			var ssdCapacities = new List<SSDCapacity>()
			{
				new SSDCapacity() { Id = 1, Value = 1 },
				new SSDCapacity() { Id = 2, Value = 2 },
				new SSDCapacity() { Id = 3, Value = 3 },
			};

			this.data.AddRange(ssdCapacities);

			var videoCards = new List<VideoCard>()
			{
				new VideoCard() { Id = 1, Name = "VideoCard1" },
				new VideoCard() { Id = 2, Name = "VideoCard2" },
				new VideoCard() { Id = 3, Name = "VideoCard3" },
			};

			this.data.AddRange(videoCards);

			var types = new List<Type>()
			{
				new Type() { Id = 1, Name = "Type1" },
				new Type() { Id = 2, Name = "Type2" },
				new Type() { Id = 3, Name = "Type3" },
			};

			this.data.AddRange(types);

			var displaySizes = new List<DisplaySize>()
			{
				new DisplaySize() { Id = 1, Value = 1 },
				new DisplaySize() { Id = 2, Value = 2 },
				new DisplaySize() { Id = 3, Value = 3 },
			};

			this.data.AddRange(displaySizes);

			var laptops = new List<Laptop>()
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

			this.data.AddRange(laptops);

			var user = new User() { Id = "User1" };

			this.data.Add(user);

			var client = new Client() { Id = 1, UserId = "User1" };

			this.data.Add(client);

			this.data.SaveChanges();
		}
	}
}
