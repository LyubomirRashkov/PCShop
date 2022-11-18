using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCShop.Infrastructure.Migrations
{
    public partial class MakeUserFirsrNameAndLastNameNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfPurchases",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountOfPurchases",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "6b824249-401e-4837-a823-fb37f0d0b22b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "4c70cfc7-6387-4292-b7aa-1d7cc42e9f1f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19512f55-7aa0-4707-b60d-6588f20c2ab1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4556b66-39e9-4d43-8e04-748de8d3c6f3", "AQAAAAEAACcQAAAAEBgoBZ1MSmjP3sPCDC4ViKU6oP34rBRLE2GnBXm3oFQ+mumPhzjkTDxbk4LvBET07w==", "c3ccd965-6b94-4bf6-8af0-dc318d3c1c5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3b38c01-9e6d-4faf-83d5-e0ec48d26115",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6e1a951-c9d9-4016-9e71-85247fa56467", "AQAAAAEAACcQAAAAEJbyh0K1TZLGxk9crAZTp9sjXwwC6JcFOl7hHdqStwkIjSBksF/1v3JsUCmsDS7V5w==", "3759018b-e1c2-4448-84ca-82b8aab8c6f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdf4e641-9248-44d4-8d23-ca09ad4ad793",
                columns: new[] { "ConcurrencyStamp", "CountOfPurchases", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b02ec07-418f-47d5-9b30-417edffd17e9", 7, "AQAAAAEAACcQAAAAEC22OepFJvvAFy2bgWU8MGsZYJZMTBYMsCfHeto6BxK/sXllj5M1garH/VhGQzu4eA==", "aaf1e2e8-c267-457b-b4b8-1020b7055b34" });
        }
    }
}
