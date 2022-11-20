using PCShop.Core.Exceptions;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Interfaces;
using PCShop.Infrastructure.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// PCShopServiceCollectionExtension model
    /// </summary>
    public static class PCShopServiceCollectionExtension
	{
        /// <summary>
        /// Extension method for adding services to the IoC container
        /// </summary>
        /// <param name="services">IServiceCollection that will be extended</param>
        /// <returns>Extended IServiceCollection</returns>
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<ILaptopService, LaptopService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IGuard, Guard>();

			return services;
        }
	}
}
