using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static PCShop.Infrastructure.Constants.DataConstant.RoleConstants;

namespace PCShop.Infrastructure.Data.Configuration
{
    /// <summary>
    /// RoleConfiguration model
    /// </summary>
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        /// <summary>
        /// Configures the entity of type IdentityRole
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(this.CreateRoles());
        }

        private List<IdentityRole> CreateRoles()
        {
            var roles = new List<IdentityRole>();

            var role = new IdentityRole()
            {
                Id = "389271c7-6194-48d3-8402-7b1b28430a42",
                Name = Administrator,
                NormalizedName = Administrator.ToUpper(),
            };

            roles.Add(role);

            role = new IdentityRole()
            {
                Id = "1b99a7a0-ca76-495f-9dff-2c486a558005",
                Name = SuperUser,
                NormalizedName = SuperUser.ToUpper(),
            };

            roles.Add(role);

            return roles;
        }
    }
}
