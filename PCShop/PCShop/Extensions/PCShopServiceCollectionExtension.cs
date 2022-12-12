using PCShop.Core.Exceptions;
using PCShop.Core.Services.Implementations;
using PCShop.Core.Services.Implementations.AdministrationArea;
using PCShop.Core.Services.Interfaces;
using PCShop.Core.Services.Interfaces.AdministrationArea;
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
        /// <param name="services">The IServiceCollection that will be extended</param>
        /// <returns>Extended IServiceCollection</returns>
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<ILaptopService, LaptopService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMonitorService, MonitorService>();
            services.AddScoped<IKeyboardService, KeyboardService>();
            services.AddScoped<IMouseService, MouseService>();
            services.AddScoped<IHeadphoneService, HeadphoneService>();
            services.AddScoped<IMicrophoneService, MicrophoneService>();

            services.AddScoped<IAdminUserService, AdminUserService>();

            services.AddScoped<IGuard, Guard>();

			return services;
        }
	}
}
