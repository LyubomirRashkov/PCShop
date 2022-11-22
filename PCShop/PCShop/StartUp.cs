using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCShop.Infrastructure.Data;
using PCShop.Infrastructure.Data.Models.Account;
using PCShop.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
	options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");

	options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:RequireUniqueEmail");

	options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength");
	options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric");
	options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric");
	options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase");
	options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:RequireLowercase");
})
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Account/SignIn";
	options.LogoutPath = "/Account/Signout";
});

builder.Services.AddMvc(options =>
{
	options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddControllersWithViews()
	.AddMvcOptions(options => 
	{
		options.ModelBinderProviders.Insert(0, new DoubleModelBinderProvider());
		options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
	});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Home/Error/500");
	app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
