using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCShop.Infrastructure.Migrations
{
    public partial class UserRolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "0ee8af0b-8346-4c2a-a17e-8ee42721ecbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "311300d9-db3e-4f5b-8009-898a4fb1e0b4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19512f55-7aa0-4707-b60d-6588f20c2ab1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "428cf562-8388-47b0-bd5b-af6d55c33f0c", "AQAAAAEAACcQAAAAEMDexROnO8faBbYRrLzf4IYSpGDdESRQzSR+P7EfdskX4z6PNPRYoXee8rAW6BMdpw==", "102b9b6c-b253-4b6d-98e6-55f049d37fda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3b38c01-9e6d-4faf-83d5-e0ec48d26115",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f078197-c3d0-4b1c-827d-4fd82c6c3b50", "AQAAAAEAACcQAAAAEF/DNXKGGgT7yO05YQ6KebVaSIvppE1QvMqBJ/2IWvH5H8UlkZrFY0yQJURHycRIHg==", "b230da9b-159f-4e41-bb7f-9b3b73478d4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdf4e641-9248-44d4-8d23-ca09ad4ad793",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "251b718c-ec8b-43db-9c3d-ac7d93d5c571", "AQAAAAEAACcQAAAAEG3XxO2Y6lZfd7vb+2d47IxnJEfsw0HUdDVFs7MKYDHJMJuzlci6rwcMxvz6HvUYtA==", "19982db7-a602-4a43-b899-cdfcf4e7560f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "5ae91a61-98a3-431c-a265-473f8d98e12e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "daa28100-a397-4e03-819e-cbd1144e6882");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19512f55-7aa0-4707-b60d-6588f20c2ab1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73fd1597-f8ce-4977-b642-c799f2b19505", "AQAAAAEAACcQAAAAEETtdzH7pRzOfrmIimf/5OSNzr5o3p/qjV2ankLrvIGKRjH9HDmaNdUajH+2Hp2gvA==", "ea4ffc4a-9f73-4691-85e3-31e7fb348365" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3b38c01-9e6d-4faf-83d5-e0ec48d26115",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76789368-c871-4ac9-bcff-145cbbc29829", "AQAAAAEAACcQAAAAEBsl4EiXI0i9l3zHU12QBj70IFkLxmGXBGLgi+6CYT9KHE0QFmFtd7LxEqNjA0RCJA==", "11b585f9-7fb2-4358-be13-96662ec8ec78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdf4e641-9248-44d4-8d23-ca09ad4ad793",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c2eeae8-9ecf-4546-8b38-98318678c3da", "AQAAAAEAACcQAAAAEGB20bsUVQoF9XFgTk8+WR734LFBH2T/2knO+N6SvnVtj17LiomhAP3NtI4IwHu08w==", "57f3367f-68a6-4f2f-90e4-ab8774520de2" });
        }
    }
}
