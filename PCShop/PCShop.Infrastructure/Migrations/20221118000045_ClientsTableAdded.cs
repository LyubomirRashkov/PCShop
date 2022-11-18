using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCShop.Infrastructure.Migrations
{
    public partial class ClientsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Headphones_AspNetUsers_SellerId",
                table: "Headphones");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyboards_AspNetUsers_SellerId",
                table: "Keyboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_AspNetUsers_SellerId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_Mice_AspNetUsers_SellerId",
                table: "Mice");

            migrationBuilder.DropForeignKey(
                name: "FK_Microphones_AspNetUsers_SellerId",
                table: "Microphones");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_AspNetUsers_SellerId",
                table: "Monitors");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Monitors",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Microphones",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Mice",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Laptops",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Keyboards",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                table: "Headphones",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountOfPurchases = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CountOfPurchases", "UserId" },
                values: new object[] { 1, 7, "fdf4e641-9248-44d4-8d23-ca09ad4ad793" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Headphones_Clients_SellerId",
                table: "Headphones",
                column: "SellerId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyboards_Clients_SellerId",
                table: "Keyboards",
                column: "SellerId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Clients_SellerId",
                table: "Laptops",
                column: "SellerId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mice_Clients_SellerId",
                table: "Mice",
                column: "SellerId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Microphones_Clients_SellerId",
                table: "Microphones",
                column: "SellerId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Clients_SellerId",
                table: "Monitors",
                column: "SellerId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Headphones_Clients_SellerId",
                table: "Headphones");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyboards_Clients_SellerId",
                table: "Keyboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Clients_SellerId",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_Mice_Clients_SellerId",
                table: "Mice");

            migrationBuilder.DropForeignKey(
                name: "FK_Microphones_Clients_SellerId",
                table: "Microphones");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Clients_SellerId",
                table: "Monitors");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Monitors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Microphones",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Mice",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Laptops",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Keyboards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerId",
                table: "Headphones",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "089e527e-13e0-497b-927c-57b9fb3b47f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "1ec8c510-f1c6-4c9c-a370-aa37b3e1edab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19512f55-7aa0-4707-b60d-6588f20c2ab1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2fbb752-ccef-4eca-9a78-91400fc166ba", "AQAAAAEAACcQAAAAEONWpXdWAEHcuv7zLXlrrVV3cik6MYFYc8ovH449E8lvx1cjSsKZdkO6EHVIXwA9ag==", "b0adb32d-f618-48bc-bc69-65dac2cf89f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3b38c01-9e6d-4faf-83d5-e0ec48d26115",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7f436ce-3fa7-477d-bd01-d8471c92bea1", "AQAAAAEAACcQAAAAEJP2CJs+8lZi7DiqvobbBxPsqsjwIe2bANS73A/NPLIrYEp0WsBxODGmte6be3jYPA==", "34304971-edcd-4f9b-952b-df937fec4f82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdf4e641-9248-44d4-8d23-ca09ad4ad793",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0db04864-0b89-4600-bad2-0b355144d324", "AQAAAAEAACcQAAAAEHo0FvfIg1E11fD3xtcTB4ey8wI9Oe5UEbAXpQYoytXHLFcyv0S3ppqQsNT2HrJlyg==", "0d52d318-3640-4438-b8be-c361dec52e70" });

            migrationBuilder.AddForeignKey(
                name: "FK_Headphones_AspNetUsers_SellerId",
                table: "Headphones",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyboards_AspNetUsers_SellerId",
                table: "Keyboards",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_AspNetUsers_SellerId",
                table: "Laptops",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mice_AspNetUsers_SellerId",
                table: "Mice",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Microphones_AspNetUsers_SellerId",
                table: "Microphones",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_AspNetUsers_SellerId",
                table: "Monitors",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
