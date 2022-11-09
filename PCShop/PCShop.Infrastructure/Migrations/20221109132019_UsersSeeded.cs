using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCShop.Infrastructure.Migrations
{
    public partial class UsersSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "b827eddf-2ac9-4169-b2c8-cc76cae95c1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "256756ab-4e12-4072-8faa-b2b6d262b886");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CountOfPurchases", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "19512f55-7aa0-4707-b60d-6588f20c2ab1", 0, "d9ed0bd7-0b0a-45b3-8f9b-c68c59299979", 0, "admin@mail.com", false, "Admin-FN", "Admin-LN", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEJcwHd8SHeAspsifxCQFOpnDuxK7NJgvOldxwZPane2LKQT8mIldzlZBEcL88AskbQ==", null, false, "1fe6daa5-2f5f-4e73-b683-e08cb78ae26a", false, "admin" },
                    { "b3b38c01-9e6d-4faf-83d5-e0ec48d26115", 0, "016f4cfc-0add-4fdd-8ded-8d0d776eddd0", 0, "user@mail.com", false, "User-FN", "User-LN", false, null, "USER@MAIL.COM", "USER", "AQAAAAEAACcQAAAAEDmQxMcQbSOM5DZ3jdxz8GHwMP0qzCImWW4bw4IwOUWsegjt4ba7/SGMm4WDPg/q9g==", null, false, "28d2fada-6f9b-4a85-88c5-68b1e1889cb4", false, "user" },
                    { "fdf4e641-9248-44d4-8d23-ca09ad4ad793", 0, "bde7aee2-41f6-47c4-9cf8-e030ba248c2b", 7, "superUser@mail.com", false, "SuperUser-FN", "SuperUser-LN", false, null, "SUPERUSER@MAIL.COM", "SUPERUSER", "AQAAAAEAACcQAAAAEOexJhaqgGdL4pYzlOb7gDtHV2y5XslvjiUlLwVQOCXm9QBhDVvZ/qFSViTjyShWLw==", null, false, "b105d3ce-ccc2-413d-8642-8abcdad66f05", false, "superUser" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19512f55-7aa0-4707-b60d-6588f20c2ab1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3b38c01-9e6d-4faf-83d5-e0ec48d26115");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdf4e641-9248-44d4-8d23-ca09ad4ad793");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "14b0b3d7-5ac3-4520-a53d-25736573c57a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "f2fa5b94-0978-4cb6-82b9-807bdd93ae4b");
        }
    }
}
