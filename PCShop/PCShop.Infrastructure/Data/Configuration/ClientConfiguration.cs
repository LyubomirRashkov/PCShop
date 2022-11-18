using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCShop.Infrastructure.Data.Models;

namespace PCShop.Infrastructure.Data.Configuration
{
    /// <summary>
    /// ClientConfiguration model
    /// </summary>
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        /// <summary>
        /// Configures the entity of type Client
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type</param>
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(this.CreateClients());
        }

        private List<Client> CreateClients()
        {
            var clients = new List<Client>();

            var client = new Client()
            {
                Id = 1,
                UserId = "fdf4e641-9248-44d4-8d23-ca09ad4ad793",
                CountOfPurchases = 7,
            };

            clients.Add(client);

            return clients;
        }
    }
}
