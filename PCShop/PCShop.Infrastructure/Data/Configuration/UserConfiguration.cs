using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCShop.Infrastructure.Data.Models.Account;
using static PCShop.Infrastructure.Constants.DataConstant.UserConstants;

namespace PCShop.Infrastructure.Data.Configuration
{
    /// <summary>
    /// UserConfiguration model
    /// </summary>
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the entity of type User
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(this.CreateUsers());
        }

        private List<User> CreateUsers()
        {
            var users = new List<User>();

            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "19512f55-7aa0-4707-b60d-6588f20c2ab1",
                UserName = AdminUserName,
                NormalizedUserName = AdminUserName.ToUpper(),
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Admin-FN",
                LastName = "Admin-LN",
            };

            user.PasswordHash = hasher.HashPassword(user, "admin");

            users.Add(user);

            user = new User()
            {
                Id = "fdf4e641-9248-44d4-8d23-ca09ad4ad793",
                UserName = SuperUserUserName,
                NormalizedUserName = SuperUserUserName.ToUpper(),
                Email = "superUser@mail.com",
                NormalizedEmail = "SUPERUSER@MAIL.COM",
                FirstName = "SuperUser-FN",
                LastName = "SuperUser-LN",
            };

            user.PasswordHash = hasher.HashPassword(user, "superUser");

            users.Add(user);

            user = new User()
            {
                Id = "b3b38c01-9e6d-4faf-83d5-e0ec48d26115",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM",
                FirstName = "User-FN",
                LastName = "User-LN",
            };

            user.PasswordHash = hasher.HashPassword(user, "user");

            users.Add(user);

            return users;
        }
    }
}
