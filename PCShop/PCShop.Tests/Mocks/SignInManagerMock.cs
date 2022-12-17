using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PCShop.Infrastructure.Data.Models.Account;

namespace PCShop.Tests.Mocks
{
	public class SignInManagerMock
	{
		public static SignInManager<User> MockSignInManager()
		{
			Mock<UserManager<User>> userManager = new Mock<UserManager<User>>(
				new Mock<IUserStore<User>>().Object,
				new Mock<IOptions<IdentityOptions>>().Object,
				new Mock<IPasswordHasher<User>>().Object,
				Array.Empty<IUserValidator<User>>(),
				Array.Empty<IPasswordValidator<User>>(),
				new Mock<ILookupNormalizer>().Object,
				new Mock<IdentityErrorDescriber>().Object,
				new Mock<IServiceProvider>().Object,
				new Mock<ILogger<UserManager<User>>>().Object);

			Mock<SignInManager<User>> signInManager = new Mock<SignInManager<User>>(
				userManager.Object,
				new Mock<IHttpContextAccessor>().Object,
				new Mock<IUserClaimsPrincipalFactory<User>>().Object,
				new Mock<IOptions<IdentityOptions>>().Object,
				new Mock<ILogger<SignInManager<User>>>().Object,
				new Mock<IAuthenticationSchemeProvider>().Object);

			signInManager
				.Setup(sm => sm.SignOutAsync())
				.Returns(Task.CompletedTask);

			signInManager
				.Setup(sm => sm.RefreshSignInAsync(It.IsAny<User>()))
				.Returns(Task.CompletedTask);

			return signInManager.Object;
		}
	}
}
