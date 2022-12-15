using Microsoft.EntityFrameworkCore;
using PCShop.Infrastructure.Data;

namespace PCShop.Tests.Mocks
{
	public static class DatabaseMock
	{
		public static ApplicationDbContext Instance 
		{
			get 
			{
				var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
					.UseInMemoryDatabase("PCShopInMemoryDb" + DateTime.Now.Ticks.ToString())
					.Options;

				return new ApplicationDbContext(dbContextOptions, false);
			}
		}
	}
}
