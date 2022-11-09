using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCShop.Infrastructure.Migrations
{
    public partial class AddRelationBetweenUsersAndProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Monitors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Microphones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Mice",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Laptops",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Keyboards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Headphones",
                type: "nvarchar(450)",
                nullable: true);

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
                value: "14b0b3d7-5ac3-4520-a53d-25736573c57a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "f2fa5b94-0978-4cb6-82b9-807bdd93ae4b");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_SellerId",
                table: "Monitors",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Microphones_SellerId",
                table: "Microphones",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Mice_SellerId",
                table: "Mice",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_SellerId",
                table: "Laptops",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyboards_SellerId",
                table: "Keyboards",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Headphones_SellerId",
                table: "Headphones",
                column: "SellerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Monitors_SellerId",
                table: "Monitors");

            migrationBuilder.DropIndex(
                name: "IX_Microphones_SellerId",
                table: "Microphones");

            migrationBuilder.DropIndex(
                name: "IX_Mice_SellerId",
                table: "Mice");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_SellerId",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Keyboards_SellerId",
                table: "Keyboards");

            migrationBuilder.DropIndex(
                name: "IX_Headphones_SellerId",
                table: "Headphones");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Microphones");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Mice");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Headphones");

            migrationBuilder.DropColumn(
                name: "CountOfPurchases",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b99a7a0-ca76-495f-9dff-2c486a558005",
                column: "ConcurrencyStamp",
                value: "23109158-0204-4bac-8af2-af50f5183e3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389271c7-6194-48d3-8402-7b1b28430a42",
                column: "ConcurrencyStamp",
                value: "dfc1e3cb-1b61-45b1-84ae-43cba1d0225f");
        }
    }
}
