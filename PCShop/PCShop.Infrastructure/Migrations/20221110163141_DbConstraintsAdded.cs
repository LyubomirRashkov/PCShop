using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCShop.Infrastructure.Migrations
{
    public partial class DbConstraintsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VideoCards",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Types",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Range",
                table: "Sensitivities",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Resolutions",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Formats",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DisplayTechnologies",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DisplayCoverages",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CPUs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b02ec07-418f-47d5-9b30-417edffd17e9", "AQAAAAEAACcQAAAAEC22OepFJvvAFy2bgWU8MGsZYJZMTBYMsCfHeto6BxK/sXllj5M1garH/VhGQzu4eA==", "aaf1e2e8-c267-457b-b4b8-1020b7055b34" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VideoCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Types",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Range",
                table: "Sensitivities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Resolutions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Formats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DisplayTechnologies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DisplayCoverages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "0e7b6312-f1e7-4b4c-af13-542911ab6986");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "c39ed361-fedf-483d-9e72-399c1de28dd3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19512f55-7aa0-4707-b60d-6588f20c2ab1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc9419ac-996d-48c1-9f34-4d09d4bca5cc", "AQAAAAEAACcQAAAAEN14HQLSO2sm/LxVvYBUhFRr681bq9I5sIIicWGiRzcrC22YiffJekEHgV7pcRAJrg==", "04617e3c-8b9e-4d2a-afc0-3aea1b367a2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3b38c01-9e6d-4faf-83d5-e0ec48d26115",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "349422aa-9f6c-445c-a2a9-309a3e92122a", "AQAAAAEAACcQAAAAENP12HQlEdKc/zpgFJ5boR0Pp6/6PPLIcT98z3Q8bFKNQOALvwL6/tcSAUcZ8efBhA==", "52a81ccc-fe81-4ef4-a85f-18eb747ffa37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdf4e641-9248-44d4-8d23-ca09ad4ad793",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07c44f41-2235-42aa-a68f-2d3de0bce4cd", "AQAAAAEAACcQAAAAEJLHRsO5dvT1iHRUy5F1QrE0/ivkMcraEpxExiHzUFmX3BcIpncXYR7d0TU3xdMUPA==", "b0b5b121-9b3e-4eee-b8cf-67bb820d2c84" });
        }
    }
}
