using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PCShop.Infrastructure.Data.Models.Account;

namespace PCShop.Tests.Mocks
{
	public class UserManagerMock
	{
		public static UserManager<User> MockUserManager(List<User> users)
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

			userManager
				.Setup(um => um.FindByIdAsync(It.IsAny<string>()))!
				.ReturnsAsync((string id) => users.FirstOrDefault(u => u.Id == id));

			userManager
				.Setup(um => um.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
				.ReturnsAsync((User user, string role) => IdentityResult.Success);

			return userManager.Object;
		}
	}
}
